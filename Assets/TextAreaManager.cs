using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAreaManager : MonoBehaviour
{
    public GameObject textObject;
    AudioSource clickSound;
    // Start is called before the first frame update
    void Start()
    {
        this.clickSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetText(string description)
    {
        this.clickSound.Play();
        this.textObject.GetComponent<TMPro.TextMeshProUGUI>().text = description;
    }
}
