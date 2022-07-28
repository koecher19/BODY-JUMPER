using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool hasVisualSelection;
    [TextArea] public string description;
    [HideInInspector] public bool collidingWithPlayer;
    SpriteRenderer sprite; // sprite renderer is either the object itself OR (if hasVisualSelection) the border which shows when you can interact with the object
    TextAreaManager textAreaManager;


    // Start is called before the first frame update
    void Start()
    {
        this.sprite = GetComponent<SpriteRenderer>();
        this.textAreaManager = GameObject.Find("Frame").GetComponent<TextAreaManager>();

        if (this.hasVisualSelection)
        {
            this.sprite.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.hasVisualSelection)
        {
            DisplayFrame();
        }
        if (this.collidingWithPlayer)
        {
            DisplayText();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.collidingWithPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.collidingWithPlayer = false;
        }
    }

    void DisplayFrame()
    {
        if (this.collidingWithPlayer)
        {
            this.sprite.enabled = true;
        }
        else
        {
            this.sprite.enabled = false;
        }
    }

    void DisplayText()
    {
        /*
         * Displays Text in Textarea when player presses SPACE
         */

        if(this.description != "")
        {
            if (Input.GetKeyDown("space"))
            {
                // call text display to display this objects description
                this.textAreaManager.SetText(this.description);
            }
        }
    }

}
