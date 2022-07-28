using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyScript : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject possOnFloorTrigger;
    public bool lastDoorMens;

    public int textIteratorMens;
    public int textIteratorWomens;
    public int textIterator;
    public int maxTextIterationsMens;
    public int maxTextIterationsWomens;
    public int maxTextIterationsOther;


    // Start is called before the first frame update
    void Start()
    {
        this.initDoors();
        StartCoroutine(timedIntro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggeredDoor(GameObject door)
    {
        /*
         * handles monologue triggered by bathroom doors
         */

        if(door.gameObject.name == "door_mens" && !this.lastDoorMens)
        {

            // set text iterator one further
            if(this.maxTextIterationsMens >= this.textIteratorMens)
            {
                // dispaly next dialog:
                List<int> i = new List<int>();
                i.Add(this.textIteratorMens);
                List<bool> icon = new List<bool>();
                icon.Add(true);
                this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, icon);

                this.textIteratorMens += 1;
            }
            if(this.maxTextIterationsMens < this.textIteratorMens) // after last text:
            {
                // enable piss-on-floor-trigger:
                this.possOnFloorTrigger.SetActive(true);
            }

            // remember that we went to this door
            this.lastDoorMens = true;

        }
        else if(door.gameObject.name == "door_womens" && this.lastDoorMens)
        {
            
            // set text iterator one further
            if (this.maxTextIterationsWomens >= this.textIteratorWomens)
            {
                // dispaly next dialog:
                List<int> i = new List<int>();
                i.Add(this.textIteratorWomens);
                List<bool> icon = new List<bool>();
                icon.Add(true);
                this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, icon);

                this.textIteratorWomens += 1;
            }

            // remember that we went to this door
            this.lastDoorMens = false;
        }
    }


    IEnumerator timedIntro()
    {
        // wait for one second
        yield return new WaitForSeconds(3.0f);
        // display first text
        List<int> i = new List<int>();
        i.Add(0);
        List<bool> icon = new List<bool>();
        icon.Add(true);
        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, icon);
        // iterate text 
    }

    void initDoors()
    {
        this.textIterator = 0;
        this.textIteratorWomens = 10;
        this.textIteratorMens = 6;

        this.maxTextIterationsOther = this.textDisplay.GetComponent<BetterTextManager>().textFiles.Count - 1;
        this.maxTextIterationsMens = 9;
        this.maxTextIterationsWomens = 12;

        this.lastDoorMens = false;
    }

    public void mightAsWell()
    {
        /*
         * is triggered by PissOnFloorTrigger
         * 0. unlock urinating --> pissOnfloorTrigger
         * 1. dialog: might as well 
         * 2. dialog: "press p"
         * 3. player presses p --> playerMovement
         * 4. game continues
         */

        // 1. dialog
        // press space for next dialog
        this.textDisplay.GetComponent<BetterTextManager>().peeScene = true;

        List<int> i = new List<int>();
        i.Add(1);
        i.Add(2);
        List<bool> icon = new List<bool>();
        icon.Add(true);
        icon.Add(false);
        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, icon);
        


    }

    public void hitANewLow()
    {
        /*
        // dialog: i think ive hit a new low
        this.textDisplay.GetComponent<TextManager>().displayText(3, "other", true);
        // dialog: but i dont really care
        this.textDisplay.GetComponent<TextManager>().setNextDialog(4, "other", true);
        // dialog: fuck you all
        //this.textDisplay.GetComponent<TextManager>().setNextDialog(5, "other", true);
        */

        List<int> i = new List<int>();
        i.Add(3);
        i.Add(4);
        i.Add(5);
        List<bool> heads = new List<bool>();
        heads.Add(true);
        heads.Add(true);
        heads.Add(true);

        this.textDisplay.GetComponent<BetterTextManager>().fillBuffer(i, heads);

    }

    /*
    public IEnumerator hitANewLowTimed()
    {
        Debug.Log("new low event started!");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("waiting is over");
        this.hitANewLow();
    }
    */

}
