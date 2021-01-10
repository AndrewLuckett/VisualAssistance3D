using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOA_TriggeredSound : MonoBehaviour, GOA_Triggerable {
    /**
    * Game object Attribute - Make Sound 
    * Plays a single sound per trigger
    * Plays each sound in order
    * Loops back to sound 0 if cycle = true
    **/
    private int index = 0;

    public AudioSource source;
    public bool cycle = false;
    public AudioClip[] sounds;

    public TriggerResponses trigger() {
        source.PlayOneShot(sounds[index]);

        index++;

        if(index >= sounds.Length)
            if(cycle)
                index = 0;
            else
                index = sounds.Length - 1;

        return TriggerResponses.normal;
    }
}
