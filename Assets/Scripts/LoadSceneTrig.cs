using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrig : MonoBehaviour
{
    public int loadSceneWithOffset;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // loads next scene in build-manager order
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + this.loadSceneWithOffset);
        }
    }
}
