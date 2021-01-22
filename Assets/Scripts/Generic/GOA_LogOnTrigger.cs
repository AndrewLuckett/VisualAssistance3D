using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOA_LogOnTrigger : MonoBehaviour, TriggerableInterface {
    /**
    * Game object Attribute - Logger
    **/
    public string text = "Trigger Logger : logging";

    public TriggerResponses trigger() {
        Debug.Log(text);
        return TriggerResponses.normal;
    }
}
