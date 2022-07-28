using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newLowManager : MonoBehaviour
{
    /*
    * gets activated by piss on floor trigger
    */
    public GameObject storyManager;
    public GameObject otherTrig;
    public GameObject[] walls;
    public GameObject leave_arrow;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        this.leave_arrow = GameObject.Find("arrow");
        this.leave_arrow.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.newLow();
        }
    }


    void newLow()
    {
        // call story manager function for this event
        this.storyManager.GetComponent<storyScript>().hitANewLow();
        // deactivate other triggger
        this.otherTrig.SetActive(false);
        // set walls as scene exits:
        foreach(var wall in this.walls)
        {
            wall.GetComponent<BoxCollider2D>().isTrigger = true; // converts wall colliders to triggers
        }

        // activate arrow
        this.leave_arrow.GetComponent<SpriteRenderer>().enabled = true;
        // deactivate this trigger
        this.gameObject.SetActive(false);
    }
}
