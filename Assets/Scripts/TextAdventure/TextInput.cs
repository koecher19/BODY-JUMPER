using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInput : MonoBehaviour
{
    public TMP_InputField inputField;

    TAGameController controller;
    GameObject menu;

    void Awake()
    {
        this.controller = GetComponent<TAGameController>();
        this.inputField.onEndEdit.AddListener(AcceptStringInput);
        this.menu = GameObject.FindGameObjectsWithTag("Menu")[0];

        this.inputField.ActivateInputField();
    }

    void AcceptStringInput(string userInput)
    {
        /*
         * gets input string from input field then seperates the words into verb-noun format and sees if controller has a response to it
         */

        userInput = userInput.ToLower();
        controller.LogStringWithReturn("> " + userInput); // here the input is logged 
        
        // second half of function has been moved to --> IEnumerator delayInputResponse()
        this.controller.DisplayLoggedText();
        StartCoroutine(delayInputResponse(userInput));

        
        
        // "the characters that we are looking for to seperate our words are gonna be spaces":
        /*
        char[] delimiterCharacters = { ' ' }; 
        string[] seperatedInputWords = userInput.Split(delimiterCharacters);

        for (int i = 0; i < this.controller.inputActions.Length; i++)
        {
            InputAction inputAction = this.controller.inputActions[i];
            if(inputAction.keyWord == seperatedInputWords[0])
            {
                inputAction.RespondToInput(this.controller, seperatedInputWords);
            }
        }

        this.InputComplete();
        */
    }

    IEnumerator delayInputResponse(string userInput)
    {
        
        yield return new WaitForSeconds(0.4f);

        // "the characters that we are looking for to seperate our words are gonna be spaces":
        char[] delimiterCharacters = { ' ' };
        string[] seperatedInputWords = userInput.Split(delimiterCharacters);

        for (int i = 0; i < this.controller.inputActions.Length; i++)
        {
            InputAction inputAction = this.controller.inputActions[i];
            if (inputAction.keyWord == seperatedInputWords[0])
            {
                inputAction.RespondToInput(this.controller, seperatedInputWords);
            }
        }

        this.InputComplete();
    }

    void InputComplete()
    {
        /*
         * after input: display the new text, make shure youre still in the input field and delete last text form input field
         */
        
        this.controller.DisplayLoggedText();

        if (!this.menu.activeSelf)
        {
            this.inputField.ActivateInputField();
        }

        this.inputField.text = null;
    }
}
