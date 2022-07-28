using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPanel : MonoBehaviour
{
    public Button yes;
    public Button no;

    // Start is called before the first frame update
    void Start()
    {
        // start input panel as inactive
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void yesButton()
    {
        Debug.Log("yes!");
        this.gameObject.SetActive(false);
    }

    public void noButton()
    {
        Debug.Log("no!");
        this.gameObject.SetActive(false);
    }

    public IEnumerator test()
    {
        Debug.Log("IEnumerator activated");
        yield return new WaitForSeconds(0.2f);
    }
}
