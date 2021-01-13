using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOA_Describable : MonoBehaviour {
    // Start is called before the first frame update

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

    public string getData(out Dictionary<string, string> attr) {
        attr = new Dictionary<string, string>();
        foreach(attribute a in attribs) 
            attr.Add(a.attrib_name, a.attrib_value);

        return objectName;
    }
}
