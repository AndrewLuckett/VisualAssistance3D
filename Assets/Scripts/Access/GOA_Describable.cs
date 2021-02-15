using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOA_Describable : MonoBehaviour {// , GOA_Triggerable{
    /**
    * Game object Attribute - Describable
    * Gives a gameobject data options regarding how they should be described
    **/
    public string objectName = "";
    [Range(0f, 1f)]
    public float importance = 1f;
    public Attribute[] attribs;
    //Attributes can be added and overwritten at runtime but cannot be removed
    //once they have been loaded into the dictionary
    private Dictionary<string, string> attribsD = new Dictionary<string, string>();
    //A dict is easier to work with than an array
    //Just a shame unity doesnt appear to be able to serialize them without
    //forcefully defining a wrapper class specific to the field types

    private void loadData() {
        //Not using Start() as all the describable objects loading their dicts
        //at the same time would ruin performance
        foreach(Attribute a in attribs)
            attribsD.Add(a.attrib_name, a.attrib_value);
        attribs = null;
    }

    public Description getDescription() {
        if(attribs != null) {
            loadData();
        }
        Description outD = new Description(importance, objectName, attribsD);
        return outD;
    }

    public Description getDescription(Transform from) {
        //TODO calculate weighted importance
        if(attribs != null) {
            loadData();
        }
        Description outD = new Description(importance, objectName, attribsD);
        return outD;
    }

    //Used to test
    //public TriggerResponses trigger() {
    //    Dictionary<string, string> t;
    //    string a = getData(out t);
    //    return TriggerResponses.normal;
    //}
}
