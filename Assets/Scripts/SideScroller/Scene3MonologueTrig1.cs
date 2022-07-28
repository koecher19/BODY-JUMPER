using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3MonologueTrig1 : MonoBehaviour
{
    public GameObject story;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // set monologue:
            this.story.GetComponent<StoryScript3>().monologue1();
            // disable this trigger:
            this.gameObject.SetActive(false);

        }
    }
}
