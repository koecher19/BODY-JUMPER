using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BetterTextManager : MonoBehaviour
{
    // all objects that will be displayed 
    public GameObject panel;
    public TMP_Text displayed_text;
    public GameObject headSprite;

    // stores all dialog 
    public List<TextAsset> textFiles;

    public List<int> i_buffer;      // which textFiles to read
    public List<bool> head_buffer;  // if little head avater of protag will show

    bool moreDialog;                // for dialog iteration

    public bool peeScene;           // have to press p not space
    bool onHold;                    // also for pee scene

    public GameObject player;

    // sound:
    public bool hasSound;
    public List<AudioSource> noises;

    // Start is called before the first frame update
    void Start()
    {
        this.init();
    }

    // Update is called once per frame
    void Update()
    {
        this.next();
    }

    void init()
    {
        this.panel.SetActive(false);
        this.headSprite.SetActive(false);
        this.moreDialog = false;
        this.peeScene = false;
        this.onHold = false;
    }

    public void fillBuffer(List<int> i_buffer, List<bool> head_buffer)
    {
        /*
         * gets called from other game objects to trigger dialog
         */

        // check if i and head bufer have same amount of parameters
        if(i_buffer.Count != head_buffer.Count)
        {
            Debug.Log("textManager -> fillBuffer -> Buffers must have equal length!");
        }

        this.i_buffer = i_buffer;
        this.head_buffer = head_buffer;

        this.displayBuffer();
    }

    void displayBuffer()
    {
        // as long as buffers arent empty and if text-bubble isnt active rn:
        if(this.i_buffer.Count != 0 && !this.panel.activeSelf)
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
        this.displayText(this.i_buffer[0], this.head_buffer[0]);
    }

    void displayText(int i, bool head)
    {
        /*
         * displays ith text from text files
         */

        // disable player movement:
        this.player.GetComponent<PlayerMovement>().disableMovement();

        // set to new text:
        this.displayed_text.text = this.textFiles[i].text;

        // display avatar:
        if (head)
        {
            this.headSprite.SetActive(true);
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
        // stop displaying panel:
        this.panel.SetActive(false);
        // disable avatar:
        this.headSprite.SetActive(false);
        // reenable player movement:
        StartCoroutine(waitAndEnableMovement());
    }

    IEnumerator waitAndEnableMovement()
    {
        yield return new WaitForSeconds(0.1f);
        this.player.GetComponent<PlayerMovement>().enableMovement();
    }

    void next()
    {
        /*
         * player presses space: remove text bubble or display next text
         * special-case for pee scene: player has to press p
         */

        // if buffer isnt empty: there is more dialog:
        if(this.i_buffer.Count > 0)
        {
            this.moreDialog = true;
        }

        if(Input.GetKeyDown("space") && this.panel.activeSelf && !this.onHold)
        {
            if (!this.moreDialog)   // no more dialog: just remove text-bubble
            {
                this.stopDisplayingText();
            }
            else if (!this.peeScene)    // more dialog: remove last-displayed text from buffers and show new dialog
            {
                this.stopDisplayingText();

                // remove last displayed text from buffers:
                if (this.i_buffer.Count != 0)
                {
                    this.i_buffer.RemoveAt(0);
                    this.head_buffer.RemoveAt(0);
                }
                // display new text:
                this.displayBuffer();

                this.moreDialog = false;
            }
            else if (this.peeScene)   // special case: pee scene
            {
                this.stopDisplayingText();

                this.onHold = true;

                // remove last displayed text from buffers:
                if (this.i_buffer.Count != 0)
                {
                    this.i_buffer.RemoveAt(0);
                    this.head_buffer.RemoveAt(0);
                }
                // display new text:
                this.displayBuffer();


                this.peeScene = false;
                this.moreDialog = false;
            }
            else
            {
                Debug.Log("problem with next() function of text manager");
            }
        }else if(Input.GetKeyDown("p") && this.panel.activeSelf && this.onHold)
        {
            // this means we are in the pee scene. stop displaying text by pressing p
            this.onHold = false;
            this.stopDisplayingText();

        }
    }

    void makeRandomNoise()
    {
        /*
         * chooses randomized AudioSource out of List and plays it
         */
        int randomNumber = Random.Range(0, this.noises.Count);
        this.noises[randomNumber].Play();
        Debug.Log("playing" + randomNumber);
    }

}
