using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="TextAdventure/ActionResponses/ChangeRoom")]
public class ChangeRoomResponse : ActionResponse
{
    public Room roomToChangeTo;
    [TextArea] public string roomChangeText;

    public override bool DoActionResponse(TAGameController controller)
    {
        if(controller.roomNavigation.currentRoom.roomName == this.requiredString)
        {
            controller.roomNavigation.currentRoom = this.roomToChangeTo;

            if(this.roomChangeText != "")
            {
                controller.LogStringWithReturn(this.roomChangeText);
            }
            
            controller.DisplayRoomText();
            return true;
        }
        return false;
    }
}
