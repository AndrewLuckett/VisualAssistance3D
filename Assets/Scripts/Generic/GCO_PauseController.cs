using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCO_PauseController : MonoBehaviour {
    /**
     * Game control object - Pause controller
    **/

    public GameObject pausewindow;
    private bool paused = false;

    void Start() {

    }


    void Update() {
        if(Input.GetButtonDown("Cancel")) {
            setPauseMenuActive(!paused);
        }
    }

    public void setPauseMenuActive(bool active) {
        paused = active;
        Time.timeScale = active ? 0f : 1f;
        pausewindow.SetActive(active);

        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = active;
        
    }
}
