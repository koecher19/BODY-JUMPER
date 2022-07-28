using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public Canvas menu;
    public AudioSource clickSound;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.menu.gameObject.SetActive(false);
        //this.clickSound = this.menu.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            this.clickSound.Play();
            this.player.GetComponent<PlayerMovement>().disableMovement();
            this.menu.gameObject.SetActive(true);
        }
        
    }

    public void resume()
    {
        Debug.Log("resume");
        this.clickSound.Play();
        StartCoroutine(waitAndResume());
    }

    public void exit()
    {
        this.clickSound.Play();
        StartCoroutine(waitAndExit());
    }
    
    IEnumerator waitAndEnableMovement()
    {
        yield return new WaitForSeconds(0.1f);
        this.player.GetComponent<PlayerMovement>().enableMovement();
    }

    IEnumerator waitAndResume()
    {
        yield return new WaitForSeconds(0.2f);
        this.menu.gameObject.SetActive(false);
        StartCoroutine(waitAndEnableMovement());
    }

    IEnumerator waitAndExit()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(0);

    }
}
