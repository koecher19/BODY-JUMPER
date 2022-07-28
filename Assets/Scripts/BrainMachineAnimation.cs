using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainMachineAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playSlurpAnimation()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Animator>().SetBool("startAnimation", true);
    }
}
