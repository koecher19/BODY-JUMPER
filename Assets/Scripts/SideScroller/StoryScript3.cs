using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScript3 : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject brainMachineTextDisplay;
    public GameObject transition;
    public GameObject slurpAnimation;
    public List<GameObject> monologueTrigs;
    public AudioSource transitionNoise;
    public GameObject ambientSoundManager;
    
    void Start()
    {
        // monologue trigs will be activated later
        foreach(var trig in this.monologueTrigs)
        {
            trig.gameObject.SetActive(false);
        }
    }

    public void monologue1()
    {
        // display monologue 1:
        List<int> i = new List<int>();
        i.Add(0);
        i.Add(1);
        List<bool> head = new List<bool>();
        head.Add(true);
        head.Add(true);
        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, head);
    }

    public void monologue2()
    {
        // display monologue 1:
        List<int> i = new List<int>();
        i.Add(2);
        i.Add(3);
        i.Add(4);
        i.Add(5);
        List<bool> head = new List<bool>();
        head.Add(true);
        head.Add(true);
        head.Add(true);
        head.Add(true);
        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, head);
    }

    public void monologue3()
    {
        // display monologue 1:
        List<int> i = new List<int>();
        i.Add(6);
        List<bool> head = new List<bool>();
        head.Add(true);
        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, head);
    }

    public void brainMachineTalk1()
    {
        // display brain machine monologue 1
        List<int> i = new List<int>();
        i.Add(0);
        i.Add(1);
        i.Add(0);
        i.Add(2);
        List<bool> icon = new List<bool>();
        icon.Add(true);
        icon.Add(true);
        icon.Add(true);
        icon.Add(true);
        List<int> iterationMethod = new List<int>();
        iterationMethod.Add(0);
        iterationMethod.Add(0);
        iterationMethod.Add(0);
        iterationMethod.Add(2);
        this.brainMachineTextDisplay.GetComponent<BetterBetterTextManager>().fillBuffer(i, icon, iterationMethod);
    }

    public void brainMachineTalk2()
    {
        // display brain machine monologue 1
        List<int> i = new List<int>();
        i.Add(2);
        List<bool> icon = new List<bool>();
        icon.Add(true);
        List<int> iterationMethod = new List<int>();
        iterationMethod.Add(2);
        this.brainMachineTextDisplay.GetComponent<BetterBetterTextManager>().fillBuffer(i, icon, iterationMethod);
    }

    public void brainMachineTalkDefault()
    {
        List<int> i = new List<int>();
        i.Add(0);
        List<bool> icon = new List<bool>();
        icon.Add(true);
        this.brainMachineTextDisplay.GetComponent<BetterBetterTextManager>().fillBuffer(i, icon);
    }

    public void yesToBrainSwap()
    {
        Debug.Log("YES TO BRAINSWAP!!");
        // switch to animation scene bRaInSwAp uUuUuUuuU
        
        this.transition.GetComponent<TransitionManager>().playTransitionAnimation();    // play transition
        StartCoroutine(waitAndPlayMachineAnimation());

    }

    IEnumerator waitAndPlayMachineAnimation()
    {
        yield return new WaitForSeconds(0.75f);
        this.transitionNoise.Play();
        yield return new WaitForSeconds(1.25f);

        // change audio
        this.ambientSoundManager.GetComponent<AmbientAudioManager>().muteAllAmbientSounds();
        this.ambientSoundManager.GetComponent<AmbientAudioManager>().playAudioWithIndex(3);
        // play animation
        this.slurpAnimation.GetComponent<BrainMachineAnimation>().playSlurpAnimation();

        yield return new WaitForSeconds(8.0f);
        // laod new scene:
        // load next scene in build order 
        if (SceneManager.sceneCountInBuildSettings >= SceneManager.GetActiveScene().buildIndex)
        {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            // for the demo: just load demo end scene
            //SceneManager.LoadScene(10);

        }

    }

    public void noToBrainSwap()
    {
        Debug.Log("NO TO BRAINSWAP!!");
        // activate monologue triggers:
        foreach(var trig in this.monologueTrigs)
        {
            trig.SetActive(true);
        }
    }
}
