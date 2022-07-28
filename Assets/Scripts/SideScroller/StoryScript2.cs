using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript2 : MonoBehaviour
{
    public GameObject textDisplay;

    public void monologue1()
    {
        // set monologue:
        List<int> i = new List<int>();
        i.Add(0);
        i.Add(1);
        List<bool> head = new List<bool>();
        head.Add(true);
        head.Add(true);

        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, head);
    }
}
