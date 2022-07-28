using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissOnFloorManager : MonoBehaviour
{
    public GameObject player;
    public bool collidingWithPlayer;
    public GameObject storyManager;
    public List<GameObject> doors;
    public GameObject[] hitNewLowTrigger;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.collidingWithPlayer = true;
            this.mightAsWellPissOnTheGround();

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.collidingWithPlayer = false;

        }
    }

    void mightAsWellPissOnTheGround()
    {
        // enable player to pee:
        this.player.GetComponent<PlayerMovement>().pissUnlocked = true;
        // trigger story event:
        this.storyManager.gameObject.GetComponent<storyScript>().mightAsWell();
        // diable barthroom doors:
        foreach (var door in this.doors){
            door.SetActive(false);
        }
        // set "hit a new low triger" active
        foreach(var trig in this.hitNewLowTrigger)
        {
            trig.SetActive(true);
        }
        
        /*
        // call next story event:
        StartCoroutine(this.storyManager.GetComponent<storyScript>().hitANewLowTimed());
        */

        // diable this trigger
        this.gameObject.SetActive(false);
    }
}
