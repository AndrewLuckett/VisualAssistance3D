﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTT_JustNames : MonoBehaviour, DataToTextInterface {

    public int maxElements = 10;
    public string getText(List<Description> data) {
        int m = Mathf.Min(maxElements, data.Count);
        string outs = "";
        for(int i = 0; i < m; i++) {
            outs += data[i].name;
            outs += "\n";
        }
        return outs;
    }
}
