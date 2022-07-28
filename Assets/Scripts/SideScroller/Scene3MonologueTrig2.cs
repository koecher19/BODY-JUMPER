using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3MonologueTrig2 : MonoBehaviour
{
    public GameObject story;
    public GameObject twinTrigger;
    public int trigCounter;
    
    void Start()
    {
        this.gameObject.SetActive(false);
        this.trigCounter = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.trigCounter += this.twinTrigger.GetComponent<Scene3MonologueTrig2>().trigCounter + 1;
            // set monologue:
            switch (this.trigCounter)
            {
                case 1:
                    this.story.GetComponent<StoryScript3>().monologue2();
                    break;
                default:
                    this.story.GetComponent<StoryScript3>().monologue3();
                    break;
            }

            // disable this trigger:
            this.gameObject.SetActive(false);
            this.twinTrigger.gameObject.SetActive(false);

        }
    }
}
