using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOA_Describable : MonoBehaviour {// , GOA_Triggerable{
    /**
    * Game object Attribute - Describable
    * Gives a gameobject data options regarding how they should be described
    **/

    [System.Serializable]
    public struct attribute {
        public attribute(string name, string value) {
            attrib_name = name;
            attrib_value = value;
        }
        public string attrib_name;
        public string attrib_value;
    }

    public string objectName = "";
    [Range(0f, 1f)]
    public float importance = 1f;
    public attribute[] attribs;
    //Attributes can be added and overwritten at runtime but cannot be removed
    //once they have been loaded into the dictionary
    private Dictionary<string, string> attribsD = new Dictionary<string, string>();
    //A dict is easier to work with than an array
    //Just a shame unity doesnt appear to be able to serialize them without
    //forcefully defining a wrapper class specific to the field types

    private void loadData() {
        //Not using Start() as all the describable object loading their dicts
        //at the same time would ruin performance
        foreach(attribute a in attribs)
            attribsD.Add(a.attrib_name, a.attrib_value);
        attribs = null;
    }

    public string getData(out Dictionary<string, string> attr, out float imp) {
        if(attribs != null) {
            loadData();
        }
        attr = attribsD;
        imp = importance;
        Debug.Log(attr.Count);
        return objectName;
    }

    //Used to test
    //public TriggerResponses trigger() {
    //    Dictionary<string, string> t;
    //    string a = getData(out t);
    //    return TriggerResponses.normal;
    //}
}
