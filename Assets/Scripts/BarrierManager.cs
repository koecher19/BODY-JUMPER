using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // disable sprite renderer of every barrier:
        GameObject[] barriers = GameObject.FindGameObjectsWithTag("Barrier");
        foreach (var b in barriers)
        {
            b.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
