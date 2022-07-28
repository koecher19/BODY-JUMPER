using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Help")]
public class Help : InputAction
{
    public override void RespondToInput(TAGameController controller, string[] separatedInputWords)
    {
        controller.DisplayHelp();
    }
}
