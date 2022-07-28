using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public List<InteractableObject> usableItemList = new List<InteractableObject>();

    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();


    [HideInInspector] public List<string> nounsInRoom = new List<string>();

    Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();
    List<string> nounsInInventory = new List<string>();
    TAGameController controller;

    void Awake()
    {
        this.controller = GetComponent<TAGameController>();
    }


    public string GetObjectsNotInInventory(Room currentRoom, int i)
    {
        /*
         * used in a loop. if an object is not in inventory it add it to nounsInRoom and returns its description
         */

        InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];

        if (!this.nounsInInventory.Contains(interactableInRoom.noun))
        {
            this.nounsInRoom.Add(interactableInRoom.noun);
            return interactableInRoom.description;
        }

        return null;
    }

    public void AddActionResponsesToUseDictionary()
    {
        /*
         * used in loop. if object is (not?) in inventory and one of its actions has an action response then add the object + its action response to the useDictionary if it isnt in there already. (gets called when an objects gets taken)
         */

        for (int i = 0; i < this.nounsInInventory.Count; i++)
        {
            string noun = this.nounsInInventory[i];

            InteractableObject interactableObjectInInventory = GetInteractableObjectFromUsableList(noun);
            if(interactableObjectInInventory == null)
            {
                continue;
            }
            for (int j = 0; j < interactableObjectInInventory.interactions.Length; j++)
            {
                Interaction interaction = interactableObjectInInventory.interactions[j];

                if(interaction.actionResponse == null)
                {
                    continue;
                }

                if (!this.useDictionary.ContainsKey(noun))
                {
                    this.useDictionary.Add(noun, interaction.actionResponse);
                }
            }
        }
    }

    InteractableObject GetInteractableObjectFromUsableList(string noun)
    {
        /*
         * takes a noun and returns its InteractableObject IF its in the usableItemList
         */

        for (int i = 0; i < this.usableItemList.Count; i++)
        {
            if(this.usableItemList[i].noun == noun)
            {
                return this.usableItemList[i];
            }
        }
        return null;
    }

    public void DisplayInventory()
    {
        /*
         * simply displays the inventory
         */

        this.controller.LogStringWithReturn("You grab into your pockets and find: ");

        if(this.nounsInInventory.Count == 0)
        {
            this.controller.LogStringWithReturn("- nothing");
        }
        else
        {
            for (int i = 0; i < this.nounsInInventory.Count; i++)
            {
                this.controller.LogStringWithReturn("- " + this.nounsInInventory[i]);
            }
        }
    }

    public void ClearCollections()
    {
        /*
         * clears all the dictionaries and buffers
         */

        this.examineDictionary.Clear();
        this.takeDictionary.Clear();
        this.nounsInRoom.Clear();
    }

    public Dictionary<string, string> Take(string[] seperatedInputWords)
    {
        /*
         * take an object: if the object is in the room. add it to your inventory, then update useDictionary, remove item from room
         */

        string noun = seperatedInputWords[1];

        if (this.nounsInRoom.Contains(noun))
        {
            this.nounsInInventory.Add(noun);
            AddActionResponsesToUseDictionary();
            this.nounsInRoom.Remove(noun);
            return this.takeDictionary;
        }
        else
        {
            this.controller.LogStringWithReturn("There is no " + noun + " here to take.");
            return null;
        }
    }

    public void UseItem(string[] seperatedInputWords)
    {
        /*
         * uses item: if it is in inventory and is usable (in useDictionary) -> and then see if there is an actionresponse
         */

        string nounToUse = seperatedInputWords[1];

        if (this.nounsInInventory.Contains(nounToUse))
        {
            if (this.useDictionary.ContainsKey(nounToUse))
            {
                bool actionResult = this.useDictionary[nounToUse].DoActionResponse(this.controller); // either it works

                if (!actionResult) // or it doesnt works (used in the wrong room?)
                {
                    this.controller.LogStringWithReturn("Nothing happens.");
                }
            }
            else // if item doesnt have use-action
            {
                this.controller.LogStringWithReturn("You can't use the " + nounToUse + ".");
            }
        }
        else // if item isnt in your inventory
        {
            this.controller.LogStringWithReturn("You don't have the " + nounToUse + ".");
        }
    }
}
