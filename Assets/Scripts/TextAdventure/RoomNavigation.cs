using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;
    
    List<(Room nextRoom, string exitRepsonse)> exitResponseMap = new List<(Room nextRoom, string exitRepsonse)>();

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    TAGameController controller;
    BackgroundSoundController bgSoundController;

    void Awake()
    {
        this.controller = GetComponent<TAGameController>();
        this.bgSoundController = GetComponent<BackgroundSoundController>();
    }

    public void UnpackExitsInRoom()
    {
        /*
         * reads all exits in room and add them to to extiDictionary and sends their descriptions to the game controller to display
         */

        for (int i = 0; i < this.currentRoom.exits.Length; i++)
        {
            this.exitDictionary.Add(this.currentRoom.exits[i].keyString, this.currentRoom.exits[i].valueRoom);
            this.controller.interactionDescriptionsInRoom.Add(this.currentRoom.exits[i].exitDescription);

            this.exitResponseMap.Add((this.currentRoom.exits[i].valueRoom, this.currentRoom.exits[i].exitResponse));

            // TODO: change background sound according to current room
            this.bgSoundController.PlayRoomSound(this.currentRoom);
        }
    }

    string ReturnExitResponseForExit(Room nextRoom)
    {
        for (int i = 0; i < this.exitResponseMap.Count; i++)
        {
            if(this.exitResponseMap[i].nextRoom == nextRoom && this.exitResponseMap[i].exitRepsonse != "")
            {
                return this.exitResponseMap[i].exitRepsonse;
            }
        }
        return null;
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        /*
         * changes into new room called "directionNoun", displays new room
         * or (if we dont have an exit to this room) return message
         */

        if (this.exitDictionary.ContainsKey(directionNoun))
        {
            // display exitResponse (if there is any)
            if (ReturnExitResponseForExit(this.exitDictionary[directionNoun]) != null)
            {
                this.controller.LogStringWithReturn(ReturnExitResponseForExit(this.exitDictionary[directionNoun]));
            }
            
            this.currentRoom = this.exitDictionary[directionNoun];

            this.controller.DisplayRoomText();
        }
        else
        {
            this.controller.LogStringWithReturn("There is no path to the " + directionNoun);
        }
    }

    public void ClearExits()
    {
        /*
         * emtpies the exit dictionary
         */

        this.exitDictionary.Clear();
        this.exitResponseMap.Clear();
    }
}
