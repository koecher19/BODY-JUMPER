using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveStateLoader : MonoBehaviour
{
    public int savedSceneIndex;
    public Button intro;
    public Button one;
    public Button two;

    // Start is called before the first frame update
    void Start()
    {
        // load saved state
        this.savedSceneIndex = PlayerPrefs.GetInt("lastSceneInt");


        // set buttons inactive
        this.intro.enabled = false;
        this.one.enabled = false;
        this.two.enabled = false;
        

        if(this.savedSceneIndex >= 1)
        {
            // enable intro button
            this.intro.enabled = true;
        }
        if (this.savedSceneIndex >= 7)
        {
            // enable chapter one button
            this.one.enabled = true;
        }
        if (this.savedSceneIndex >= 9)
        {
            this.two.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSceneIndex()
    {
        if (this.savedSceneIndex >= 1)
        {
            // enable intro button
            this.intro.enabled = true;
        }
        if (this.savedSceneIndex >= 7)
        {
            // enable chapter one button
            this.one.enabled = true;
        }
        if (this.savedSceneIndex >= 9)
        {
            this.two.enabled = true;
        }
    }
}
