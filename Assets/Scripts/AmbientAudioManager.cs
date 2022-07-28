using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioManager : MonoBehaviour
{
    public List<AudioSource> sounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void muteAllAmbientSounds()
    {
        foreach(var s in this.sounds)
        {
            s.Stop();
        }
    }

    public void playAudioWithIndex(int i)
    {
        if(this.sounds.Count > i)
        {
            this.sounds[i].Play();
        }
        else
        {
            Debug.Log("AmbientAudioManager -> playAudioWithIndex : index out of range");
        }
    }

    public void pauseAudioWithIndex(int i)
    {
        if (this.sounds.Count > i)
        {
            this.sounds[i].Pause();
        }
        else
        {
            Debug.Log("AmbientAudioManager -> pauseAudioWithIndex : index out of range");
        }
    }
}
