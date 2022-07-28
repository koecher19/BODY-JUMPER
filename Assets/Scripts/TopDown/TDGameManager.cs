using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDGameManager : MonoBehaviour
{
    public GameObject[] interactablesInScene;

    // Start is called before the first frame update
    void Start()
    {
        UnpackScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UnpackScene()
    {
        // fristly: get all interactables: 
        this.interactablesInScene = GameObject.FindGameObjectsWithTag("Interactable");
    }
}
