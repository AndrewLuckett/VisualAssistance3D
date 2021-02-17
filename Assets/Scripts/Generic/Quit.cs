using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {
    public void quit() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
