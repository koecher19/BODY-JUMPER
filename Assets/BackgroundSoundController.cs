using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundController : MonoBehaviour
{
    RoomNavigation roomNavigation;
    GameObject ambientSound;
    AmbientAudioManager aaManager;

    int currentSoundIndex = 666;
    public List<Room> soundLibrary1 = new List<Room>();    // saves all room where sound with index 1 will be playing
    public List<Room> soundLibrary2 = new List<Room>();
    public List<Room> soundLibrary3 = new List<Room>();
    public List<Room> soundLibrary4 = new List<Room>();
    List<List<Room>> allLibraries = new List<List<Room>>();

    void Awake()
    {
        this.ambientSound = GameObject.Find("AmbientSound");
        this.roomNavigation = GetComponent<RoomNavigation>();
        this.aaManager = this.ambientSound.GetComponent<AmbientAudioManager>();

        // put all libraries into one list so we can search them better
        this.allLibraries.Add(this.soundLibrary1);
        this.allLibraries.Add(this.soundLibrary2);
        this.allLibraries.Add(this.soundLibrary3);
        this.allLibraries.Add(this.soundLibrary4);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRoomSound(Room currentRoom)
    {
        int i = 1; // <-- goes over libraries with foreach loop but with corresponding index of sound
        // look if current room is in one of the libraries
        foreach (var library in this.allLibraries)
        {
            if (library.Contains(currentRoom))
            {
                // check if sound is already playing:
                if ((i) == this.currentSoundIndex)
                {
                    // do nothing. just continue playing
                    return;
                }
                else
                {
                    // or else stop ambient music and play new music
                    Debug.Log("new sound!!");
                    this.aaManager.muteAllAmbientSounds();
                    this.aaManager.playAudioWithIndex(i);
                    this.currentSoundIndex = i;
                    return;
                }
            }
            i++;
        }

        // if room is in no library just mute all background sounds:
        if(this.currentSoundIndex != 666)
        {
            this.aaManager.muteAllAmbientSounds();
            this.currentSoundIndex = 999;
        }
    }
}
