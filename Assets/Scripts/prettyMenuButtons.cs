using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class prettyMenuButtons : MonoBehaviour
{
    Image buttonImage;
    Color selectedColor = new Color(0.8117647f, 0.9647059f, 0.6078432f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        this.buttonImage = GetComponent<Image>(); 
    }

    // Update is called once per frame
    void Update()
    {
        this.checkIfSelected();
    }

    void checkIfSelected()
    {
        if(this.gameObject == EventSystem.current.currentSelectedGameObject)
        {
            // this button is selected --> change color of button image
            this.buttonImage.color = this.selectedColor;
        }
        else
        {
            this.buttonImage.color = new Color(207, 246, 155, 0);
        }
    }
}
