using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Description {
    public float importance { get; }
    public string name { get; }
    public Dictionary<string, string> attribs { get; }

    public Description(float importance, string name, Dictionary<string,string> attribs) {
        this.importance = importance;
        this.name = name;
        this.attribs = attribs;
    }
}
