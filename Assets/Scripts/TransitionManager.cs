using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public GameObject Camera;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        this.setPosition();
    }
    
    void setPosition()
    {
        transform.position = new Vector3(this.Camera.transform.position.x, this.Camera.transform.position.y, transform.position.y);
    }

    public void playTransitionAnimation()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Animator>().SetBool("startTransition", true);
    }
}
