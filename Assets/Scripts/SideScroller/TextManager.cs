using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public GameObject player;

    //public int lotsOfTextIterator = 0;

    public int nextDiterator;
    public string nextDlist;
    public bool nextDhead;
    public bool onHold;
    public bool moreDialog;
    public bool peeScene;

    public List<int> i_buffer;
    public List<string> list_buffer;
    public List<bool> head_buffer;

    public GameObject pissboiHead;
    public GameObject panel;
    public TMP_Text displayed_text;

    public List<TextAsset> textfiles;
    public List<TextAsset> mensTexts;
    public List<TextAsset> womensTexts;

    // Start is called before the first frame update
    void Start()
    {
        // init not displaying panel and disabling avatar
        this.panel.SetActive(false);
        this.pissboiHead.SetActive(false);
        this.moreDialog = false;
        this.onHold = false;
        this.peeScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.textAway();
    }


    public void fillBuffer(List<int> i_buffer, List<string> list_buffer, List<bool> head_buffer)
    {
        // fill buffer
        this.i_buffer = i_buffer;
        this.list_buffer = list_buffer;
        this.head_buffer = head_buffer;

        this.displayBuffer();

    }

    void displayBuffer()
    {
        Debug.Log("display buffer");
        // as long as buffers arent empty & text-bubble isn't active rn: display next text:
        if(this.i_buffer.Count != 0 && !this.panel.activeSelf)
        {
            StartCoroutine(waitAndDisplayBuffer());

        }
    }

    public void displayText(int i, string list, bool head)
    {
        /*
         displays ith text from chosen list
         */

        // disable player movement:
        this.player.GetComponent<PlayerMovement>().disableMovement();

        // set to new text and display panel:
        switch (list)
        {
            case "mens":
                this.displayed_text.text = this.mensTexts[i].text;
                break;
            case "womens":
                this.displayed_text.text = this.womensTexts[i].text;
                break;
            case "other":
                this.displayed_text.text = this.textfiles[i].text;
                break;
        }

        // display avatar
        if (head)
        {
            this.pissboiHead.SetActive(true);
        }
        this.panel.SetActive(true);
    }

    void stopDisplayingText()
    {
        // stop displaying panel
        this.panel.SetActive(false);
        // disable avatar
        this.pissboiHead.SetActive(false);
        // reenable player movement
        StartCoroutine(waitAndEnableMovement());
    }

    void textAway()
    {
        /*
         * disables panel if player presses space
         * and shows new panel if there is more dialog to come
         */


        // if buffer isnt empty: there is more dialog:
        if (this.i_buffer.Count >= 1)
        {
            this.moreDialog = true;
        }


        
        if (Input.GetKeyDown("space") && this.panel.activeSelf && !this.onHold)
        {
            if (!this.moreDialog)   // just close text bubble
            {
                stopDisplayingText();
            }
            else if(this.peeScene) // or display next text (with condition that you press p bc thats what the story wants ewww spaghetti code)
            {
                stopDisplayingText();
                // for pee scene:
                this.onHold = true;
                StartCoroutine(waitAndDisplayNext());
                this.moreDialog = false;

                this.peeScene = false;
            }
            else // or display next text
            {
                this.stopDisplayingText();

                // remove last displayed text from buffers:
                if (this.i_buffer.Count != 0)
                {
                    this.i_buffer.RemoveAt(0);
                    this.list_buffer.RemoveAt(0);
                    this.head_buffer.RemoveAt(0);
                }

                this.displayBuffer();

                this.moreDialog = false;
            }
        }

        // release onHold
        if (Input.GetKeyDown("p") && this.panel.activeSelf)
        {
            this.onHold = false;
            stopDisplayingText();
        }
    }


    public void setNextDialog(int nextDiteration, string nextDlist, bool nextDhead)
    {
        this.moreDialog = true;
        this.nextDhead = nextDhead;
        this.nextDiterator = nextDiteration;
        this.nextDlist = nextDlist;
    }


    IEnumerator waitAndEnableMovement()
    {
        yield return new WaitForSeconds(0.1f);
        this.player.GetComponent<PlayerMovement>().enableMovement();
    }

    IEnumerator waitAndDisplayNext()
    {
        yield return new WaitForSeconds(0.2f);
        displayText(this.nextDiterator, this.nextDlist, this.nextDhead);

    }

    IEnumerator waitAndDisplayBuffer()
    {
        Debug.Log("wait and display buffer");
        yield return new WaitForSeconds(0.2f);
        // display whats in bottom of buffer
        displayText(i_buffer[0], list_buffer[0], head_buffer[0]);

    }

}

