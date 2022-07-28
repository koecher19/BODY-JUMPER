using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool collidingWithPlayer;
    public GameObject eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        this.collidingWithPlayer = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.doorHighlight();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.collidingWithPlayer = true;
            this.eventSystem.gameObject.GetComponent<storyScript>().triggeredDoor(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.collidingWithPlayer = false;
        }
    }

    void doorHighlight()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = this.collidingWithPlayer ? true : false;    // "ternary operator"
    }

}
