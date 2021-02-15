using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCO_PauseController : MonoBehaviour {
    /**
     * Game control object - Pause controller
    **/

    public GameObject pausewindow;
    private List<AudioSource> sounds;

    void Start() {
        setPauseMenuActive(pausewindow.activeSelf);
    }


    void Update() {
        if(Input.GetButtonDown("Cancel")) {
            setPauseMenuActive(!pausewindow.activeSelf);
        }
    }

    public void setPauseMenuActive(bool active) {
        Time.timeScale = active ? 0f : 1f;
        pausewindow.SetActive(active);

        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = active;


        //Warning the following sound pausing may cause desync in the long run
        if(active) {
            AudioSource[] allsounds = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            sounds = new List<AudioSource>();
            foreach(AudioSource auso in allsounds) {
                if(auso.isPlaying) {
                    sounds.Add(auso);
                    auso.Pause();
                }
            }
        } else {
            foreach(AudioSource auso in sounds) {
                auso.Play();
            }
        }

    }
}
