using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainMachineBorder : MonoBehaviour
{
    public GameObject BrainMachineText;
    public GameObject eventSystem;
    public bool collidingWithPlayer;
    public int collisionCounter;

    // Start is called before the first frame update
    void Start()
    {
        this.collidingWithPlayer = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.collisionCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.border();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.collisionCounter++;
            this.collidingWithPlayer = true;

            if (this.collidingWithPlayer)
            {
                switch (this.collisionCounter)
                {
                    case 1: 
                        this.eventSystem.GetComponent<StoryScript3>().brainMachineTalk1();
                        break;
                    default:
                        this.eventSystem.GetComponent<StoryScript3>().brainMachineTalk2();
                        break;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.collidingWithPlayer = false;
        }
    }

    void border()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = this.collidingWithPlayer ? true : false;    // "ternary operator"
    }
}
