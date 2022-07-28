using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{
    public AudioSource clickSound;
    private float delay = 0.2f;

    public void play()
    {
        this.clickSound.Play();
        StartCoroutine(waitThenPlay());
    }

    public void exitGame()
    {
        this.clickSound.Play();
        StartCoroutine(waitThenExit());
    }

    public void loadChapter(int i)
    {
        this.clickSound.Play();
        StartCoroutine(waitThenLoad(i));
    }

    IEnumerator waitThenPlay()
    {
        yield return new WaitForSeconds(this.delay);
        SceneManager.LoadScene(1);

    }
    IEnumerator waitThenExit()
    {
        yield return new WaitForSeconds(this.delay);
        Application.Quit();

    }

    IEnumerator waitThenLoad(int i)
    {
        yield return new WaitForSeconds(this.delay);
        SceneManager.LoadScene(i);

    }

}
