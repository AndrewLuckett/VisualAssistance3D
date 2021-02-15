using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTT_InOrder : MonoBehaviour, DataToTextInterface {
    public int maxElements = 10;
    public string getText(List<Description> data) {
        data.Sort((d1, d2) => d2.importance.CompareTo(d1.importance));

        int m = Mathf.Min(maxElements, data.Count);
        string outs = "";
        for(int i = 0; i < m; i++) {
            outs += data[i].importance;
            outs += "\t";
            outs += data[i].name;
            outs += "\n";
        }
        return outs;
    }
}