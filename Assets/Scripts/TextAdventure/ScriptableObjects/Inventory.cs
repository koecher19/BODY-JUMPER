using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="TextAdventure/InputActions/Inventory")]
public class Inventory : InputAction
{
    public override void RespondToInput(TAGameController controller, string[] separatedInputWords)
    {
        controller.interactableItems.DisplayInventory();
    }
}
