using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript2 : MonoBehaviour
{
    AudioSource clickSound;
    public GameObject player;
    Canvas panel;

    void Awake()
    {
        this.clickSound = GetComponent<AudioSource>();
        this.panel = GetComponent<Canvas>();
        this.player = GameObject.FindGameObjectsWithTag("Player")[0];

        this.panel.enabled = false;
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("escape pressed");
            this.clickSound.Play();
            // TODO disable player movement
            this.panel.enabled = true;

        }
        */
    }
    public void ActivateMenu()
    {
        this.clickSound.Play();
        // TODO disable player movement
        this.panel.enabled = true;
    }

    public void resume()
    {
        StartCoroutine(delayedResume());
    }

    public void exit()
    {
        this.clickSound.Play();
        StartCoroutine(delayedExit());
    }

    IEnumerator waitAndEnableMovement()
    {
        yield return new WaitForSeconds(0.1f);
        this.player.GetComponent<PlayerMovement>().enableMovement();
    }

    IEnumerator delayedResume()
    {
        Debug.Log("resume");
        this.clickSound.Play();

        yield return new WaitForSeconds(0.2f);

        this.panel.enabled = false;
        this.panel.enabled = false;
        gameObject.SetActive(false);
        //StartCoroutine(waitAndEnableMovement());
    }

    IEnumerator delayedExit()
    {
        this.clickSound.Play();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(0);

    }
}

