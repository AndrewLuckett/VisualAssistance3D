using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCF_InVision : MonoBehaviour {
    /**
     * Player character feature - Vision Objects
     * Samples an entire area and gets all objects
    **/

    public GameObject accessibleScriptParent;
    private Object accessibleScript; //TODO

    void Start() {
        accessibleScript = accessibleScriptParent.GetComponent<Object>();
    }

    public GameObject[] getAllVisible() {
        return null;
    }
}
