using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript2_1 : MonoBehaviour
{
    public GameObject textDisplay;

    public void monologue1()
    {
        List<int> i = new List<int>();
        i.Add(0);
        List<bool> head = new List<bool>();
        head.Add(true);

        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, head);

    }

    public void monologue2()
    {
        List<int> i = new List<int>();
        i.Add(1);
        List<bool> head = new List<bool>();
        head.Add(true);

        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, head);
    }
}
