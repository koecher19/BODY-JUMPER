using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TAGameController : MonoBehaviour
{
    public GameObject inputField;
    public TMP_Text displayText;
    public InputAction[] inputActions;
    [TextArea]
    public string helpText;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;

    List<string> actionLog = new List<string>();


    // this is for initialization
    void Awake()
    {
        this.roomNavigation = GetComponent<RoomNavigation>();
        this.interactableItems = GetComponent<InteractableItems>();
    }

    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();

        // init with keys in pockets:
        string[] takeKeysInputStrings = { "take", "keys" };
        this.interactableItems.Take(takeKeysInputStrings);

        // system selects input fieldvar eventSystem = EventSystem.current;
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(this.inputField, new BaseEventData(eventSystem));

    }

    public void DisplayLoggedText()
    {
        /*
         * displays all responses to actions someone does in the room
         */

        string logAsText = string.Join("\n", this.actionLog.ToArray());
        this.displayText.text = logAsText;
    }

    public void DisplayHelp()
    {
        this.LogStringWithReturn(this.helpText);
    }

    public void DisplayRoomText()
    {
        /*
         * displays room description + object descriptions + exit descriptions
         */

        ClearCollectionsForNewRoom();

        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", this.interactionDescriptionsInRoom.ToArray());
        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;
        this.LogStringWithReturn(combinedText);
    }

    void UnpackRoom()
    {
        /*
         * reads all exits and objects in the room and adds them to their dictionaries + adds their descriptions to interactionDescriptionsInRoom (to be displayed by DisplayText())
         */
        this.roomNavigation.UnpackExitsInRoom();

        PrepareObjectsToTakeOrExamine(this.roomNavigation.currentRoom);
    }

    void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        /*
         * reads all objects in the new room: adds their description to interactionDesciptionsInRoom if we dont have them in the inventory
         * then adds objects to examine and take libraries if you can examine or take them
         */

        for (int i = 0; i < currentRoom.interactableObjectsInRoom.Length; i++)
        {
            string descriptionNotInInventory = this.interactableItems.GetObjectsNotInInventory(currentRoom, i);
            if(descriptionNotInInventory != null)
            {
                this.interactionDescriptionsInRoom.Add(descriptionNotInInventory);
            }

            InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];

            for (int j = 0; j < interactableInRoom.interactions.Length; j++)
            {
                Interaction interaction = interactableInRoom.interactions[j];
                if(interaction.inputAction.keyWord == "examine")
                {
                    this.interactableItems.examineDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }
                if (interaction.inputAction.keyWord == "take")
                {
                    this.interactableItems.takeDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }
            }
        }
    }

    public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun)
    {
        /*
         * test if you actually CAN use/take/examine an object. yes? then do it. no? then get this response
         */

        if (verbDictionary.ContainsKey(noun))
        {
            return verbDictionary[noun];
        }
        else
        {
            return "You can't " + verb + " " + noun + ".";
        }
    }

    void ClearCollectionsForNewRoom()
    {
        /*
         * exiting a room, dictionaries and description-logs will be cleared
         */

        this.interactableItems.ClearCollections();
        this.interactionDescriptionsInRoom.Clear();
        this.roomNavigation.ClearExits();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        /*
         * add new string to action log with return on the end
         */

        this.actionLog.Add(stringToAdd + "\n");
    }

}
