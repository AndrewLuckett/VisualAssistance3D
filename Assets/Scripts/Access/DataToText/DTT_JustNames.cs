using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTT_JustNames : MonoBehaviour, DataToTextInterface {
    public string getText(List<Description> data) {
        string outs = "";
        foreach(Description d in data) {
            outs += d.name;
            outs += "\n";
        }
        return outs;
    }
}
