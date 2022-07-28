using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initPostPiss : MonoBehaviour
{
    /*
     * add this to eventhandler when player has dirty pants in scene
     */
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.postPissIncident();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void postPissIncident()
    {
        // enable player to pee:
        this.player.GetComponent<PlayerMovement>().pissUnlocked = true;
        this.player.GetComponent<PlayerMovement>().changeToStinky();
    }
}
