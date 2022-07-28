using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivation : MonoBehaviour
{
    GameObject menu;
    // Start is called before the first frame update
    void Awake()
    {
        this.menu = GameObject.Find("menu");
        this.menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            this.menu.SetActive(true);
            this.menu.GetComponent<MenuScript2>().ActivateMenu();
        }
    }
}
