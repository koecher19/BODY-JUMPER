using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleTriggerManager : MonoBehaviour
{
    public GameObject background;
    public AudioSource[] hummingSounds;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // change background sprite
            this.changeBackGround();

            // play sound
            foreach(var humming in this.hummingSounds)
            {
                humming.Play();
            }
            Debug.Log("humming");

            // disable this trigger
            this.gameObject.SetActive(false);
        }
    }


    void changeBackGround()
    {
        this.background.gameObject.GetComponent<backgroundManager>().switchBg(1);
    }
}
