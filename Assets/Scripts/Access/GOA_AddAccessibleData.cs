using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOA_AddAccessibleData : MonoBehaviour, TriggerableInterface {
    /**
    * Game object Attribute - Add accessible data
    * Adds data to the accessibility scheme
    * Useful for adding information like the fact a door has opened
    * Or that the user pressed a button
    * Practically as if the object was forced into view with a given
    * importance.
    **/
    public string objectName = "";
    [Range(0f,1f)]
    public float importance = 1f;

    public Attribute[] attribs;
    private Dictionary<string, string> attribsD = new Dictionary<string, string>();

    public GCO_AccessibilityHost accessibleScript;

    public TriggerResponses trigger() {
        if(attribs != null) {
            loadData();
        }
        Description d = new Description(importance, objectName, attribsD);
        accessibleScript.queueDescription(d);
        return TriggerResponses.normal;
    }

    private void loadData() {
        //Not using Start() as all the describable object loading their dicts
        //at the same time would ruin performance
        foreach(Attribute a in attribs)
            attribsD.Add(a.attrib_name, a.attrib_value);
        attribs = null;
    }
}
