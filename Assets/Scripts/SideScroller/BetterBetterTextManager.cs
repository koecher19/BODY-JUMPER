using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetterBetterTextManager : MonoBehaviour
{
    // to disable player movement
    public GameObject player;
    // to trigger further story
    public GameObject eventSystem;

    // all objects that will be displayed 
    public GameObject panel;
    public TMP_Text displayed_text;
    public GameObject iconSprite;

    // sound:
    public bool hasSound;
    public List<AudioSource> noises;
    public AudioSource inputFeedback;

    // stores all dialog 
    public List<TextAsset> textFiles;

    public List<int> i_buffer;                  // which textFiles to read
    public List<bool> icon_buffer;              // if text bubble shows icon
    public List<int> iterationMethod_buffer;    // 0: "space", 1: "p", 2: "y/n"

    // for dialog iteration:
    bool moreDialog;

    // Start is called before the first frame update
    void Start()
    {
        this.initDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        this.next();
    }

    void initDisplay()
    {
        /*
         * called at beginning of scene. 
         * initiates Display as non-active
         * bools as false
         * and lists as empty
         */

        this.panel.SetActive(false);
        this.iconSprite.SetActive(false);
        this.moreDialog = false;
        this.i_buffer = new List<int>();
        this.icon_buffer = new List<bool>();
        this.iterationMethod_buffer = new List<int>();
    }

    public void fillBuffer(List<int> i_buffer, List<bool> icon_buffer, List<int> iterationMethod_buffer)
    {
        /*
         * gets called from other game objects to trigger dialog
         */

        // check if i and icon bufer have same amount of parameters
        if (i_buffer.Count != icon_buffer.Count || i_buffer.Count != iterationMethod_buffer.Count || icon_buffer.Count != iterationMethod_buffer.Count)
        {
            Debug.Log("textManager -> fillBuffer() : Buffers must have equal length!");
        }

        this.i_buffer = i_buffer;
        this.icon_buffer = icon_buffer;
        this.iterationMethod_buffer = iterationMethod_buffer;

        this.displayBuffer();
    }

    public void fillBuffer(List<int> i_buffer, List<bool> icon_buffer)
    {
        /*
         * no iteration method buffer -> default to iteration method 0 : "space"
         */

        if (i_buffer.Count != icon_buffer.Count)
        {
            Debug.Log("textManager -> fillBuffer() : Buffers must have equal length!");
        }

        List<int> itMethod_buffer = new List<int>();
        for(int i = 0; i < i_buffer.Count; i++)
        {
            itMethod_buffer.Add(0);
        }

        this.fillBuffer(i_buffer, icon_buffer, itMethod_buffer);
    }

    void displayBuffer()
    {
        /*
         * as long as buffers arent empty and if text-bubble isnt active rn: display next item in buffer
         */

        if (this.i_buffer.Count != 0 && !this.panel.activeSelf)
        {
            StartCoroutine(waitAndDisplayBuffer());
        }
    }

    IEnumerator waitAndDisplayBuffer()
    {
        /*
         * displays first item in buffer after short delay
         */

        yield return new WaitForSeconds(0.2f);
        this.displayText(this.i_buffer[0], this.icon_buffer[0]);
    }

    void displayText(int i, bool icon)
    {
        /*
         * displays ith text from text files
         */

        // disable player movement:
        this.player.GetComponent<PlayerMovement>().disableMovement();

        // set to new text:
        this.displayed_text.text = this.textFiles[i].text;

        // display avatar:
        if (icon)
        {
            this.iconSprite.SetActive(true);
        }

        // display panel:
        this.panel.SetActive(true);

        //play sound 
        if (this.hasSound)
        {
            this.makeRandomNoise();
        }

    }

    void stopDisplayingText()
    {
        /*
         *  stops Display and reenables palyer movement
         */

        // stop displaying panel:
        this.panel.SetActive(false);
        // disable avatar:
        this.iconSprite.SetActive(false);
        // reenable player movement:
        StartCoroutine(waitAndEnableMovement());
    }

    IEnumerator waitAndEnableMovement()
    {
        /*
         * reanables player movement after short delay
         */

        yield return new WaitForSeconds(0.1f);
        this.player.GetComponent<PlayerMovement>().enableMovement();
    }

    void next()
    {
        /*
         * displays next text / stops displaying text according to player input and iterationMethod
         */

        // check if there is more text to display in the buffer
        this.moreDialog = (this.i_buffer.Count > 1) ? true : false;       // "ternary operator"

        // if buffer isnt empty: try iterating
        if(this.i_buffer.Count != 0)
        {
            if (this.panel.activeSelf && Input.GetKeyDown("space") && this.iterationMethod_buffer[0] == 0)  // iteration method = press space bar
            {
                if (!moreDialog)
                {
                    // stop display
                    this.stopDisplayingText();
                    // empty last dialog
                    this.emptyBuffer();
                }
                else
                {
                    this.stopDisplayingText();
                    // empty last dialog
                    this.emptyBuffer();
                    // display next dialog
                    this.displayBuffer();
                }
            }
            else if (this.panel.activeSelf && Input.GetKeyDown("p") && this.iterationMethod_buffer[0] == 1) // iteration method = press p
            {
                /*
                 * pee animation gets handled by PlayerMovement()
                 */

                if (!moreDialog)
                {   // stop display
                    this.stopDisplayingText();
                    // empty last dialog
                    this.emptyBuffer();
                }
                else
                {
                    // stop display
                    this.stopDisplayingText();
                    // empty last dialog
                    this.emptyBuffer();
                    // display next dialog
                    this.displayBuffer();
                }
            }
            else if (this.panel.activeSelf && (Input.GetKeyDown("y") || Input.GetKeyDown("n")) && this.iterationMethod_buffer[0] == 2) // iteration method = press y or n
            {
                if (Input.GetKeyDown("y"))
                {
                    this.eventSystem.GetComponent<StoryScript3>().yesToBrainSwap();

                    this.playInputFeedbackNoise();

                    if (!moreDialog)
                    {   // stop display
                        this.stopDisplayingText();
                        // empty last dialog
                        this.emptyBuffer();
                    }
                    else
                    {
                        // stop display
                        this.stopDisplayingText();
                        // empty last dialog
                        this.emptyBuffer();
                        // display next dialog
                        this.displayBuffer();
                    }
                }
                else if (Input.GetKeyDown("n"))
                {
                    this.eventSystem.GetComponent<StoryScript3>().noToBrainSwap();

                    this.playInputFeedbackNoise();

                    if (!moreDialog)
                    {   // stop display
                        this.stopDisplayingText();
                        // empty last dialog
                        this.emptyBuffer();
                    }
                    else
                    {
                        // stop display
                        this.stopDisplayingText();
                        // empty last dialog
                        this.emptyBuffer();
                        // display next dialog
                        this.displayBuffer();
                    }
                }
            }
        }

    }

    void playInputFeedbackNoise()
    {
        if (this.inputFeedback != null)
        {
            this.inputFeedback.Play();
        }
    }

    void emptyBuffer()
    {
        try
        {
            this.i_buffer.RemoveAt(0);
            this.icon_buffer.RemoveAt(0);
            this.iterationMethod_buffer.RemoveAt(0);
        }
        catch(System.Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    void makeRandomNoise()
    {
        /*
         * chooses randomized AudioSource out of List and plays it
         */
        int randomNumber = Random.Range(0, this.noises.Count);
        this.noises[randomNumber].Play();
        //Debug.Log("playing" + randomNumber);
    }
}
