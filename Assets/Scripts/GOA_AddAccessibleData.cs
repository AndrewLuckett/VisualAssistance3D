using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOA_AddAccessibleData : MonoBehaviour, GOA_Triggerable {
    /**
    * Game object Attribute - Add accessible data
    * Adds data to the accessibility scheme
    * Useful for adding information like the fact a door has opened
    * Or that the user pressed a button
    * Practically as if the object was forced into view with a given
    * importance.
    **/
    public string data = "";
    [Range(0f,1f)]
    public float importance = 1f;

    public GameObject accessibleScriptParent;
    private Object accessibleScript; //TODO

    void Start() {
        accessibleScript = accessibleScriptParent.GetComponent<Object>();
    }

    public TriggerResponses trigger() {
        //TODO
        return TriggerResponses.normal;
    }
}
