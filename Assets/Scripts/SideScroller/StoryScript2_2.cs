using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript2_2 : MonoBehaviour
{
    public GameObject textDisplay;

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
        List<bool> head = new List<bool>();
        head.Add(true);
        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, head);
    }
}
