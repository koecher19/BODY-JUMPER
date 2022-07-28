using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2_1MonologueTrig2 : MonoBehaviour
{
    public GameObject story;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // set monologue:
            this.story.GetComponent<StoryScript2_1>().monologue2();
            // disable this trigger:
            this.gameObject.SetActive(false);

        }
    }
}
