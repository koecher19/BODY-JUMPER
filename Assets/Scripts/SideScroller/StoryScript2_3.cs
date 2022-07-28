using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript2_3 : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject leftNextSceneTrig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void monologue1()
    {
        // display monologue 1:
        List<int> i = new List<int>();
        i.Add(0);
        i.Add(1);
        List<bool> head = new List<bool>();
        head.Add(true);
        head.Add(true);
        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, head);
        
        // set left next-scene-load-trigger to acite
        this.leftNextSceneTrig.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void monologue2()
    {
        // display monologue 2:
        List<int> i = new List<int>();
        i.Add(2);
        List<bool> head = new List<bool>();
        head.Add(true);
        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, head);
    }
}
