using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCooler : MonoBehaviour
{
    [TextArea] public string actionDescription;
    [HideInInspector] public bool collidingWithPlayer;
    TextAreaManager textAreaManager;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        this.textAreaManager = GameObject.Find("Frame").GetComponent<TextAreaManager>();
        this.sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.collidingWithPlayer)
        {
            UseWaterCooler();
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

    void UseWaterCooler()
    {

        if (this.actionDescription != "")
        {
            if (Input.GetKeyDown("space"))
            {
                // call text display to display this objects description
                this.textAreaManager.SetText(this.actionDescription);
                this.sound.Play();
            }
        }

        // TODO: also add health and reduce stress or smth
    }
}
