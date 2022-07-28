using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2_3MonologueTrig : MonoBehaviour
{
    public GameObject story;
    public GameObject rauschen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // stop rauschen2 animation
            this.rauschen.GetComponent<SpriteRenderer>().enabled = false;
            this.rauschen.GetComponent<AudioSource>().enabled = false;
            // set monologue:
            this.story.GetComponent<StoryScript2_3>().monologue1();
            // disable this trigger:
            this.gameObject.SetActive(false);

        }
    }
}
