using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundManager : MonoBehaviour
{
    public List<Sprite> sprites;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            switchBg(1);
        }
    }

    public void switchBg(int i)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.sprites[i];
    }
}
