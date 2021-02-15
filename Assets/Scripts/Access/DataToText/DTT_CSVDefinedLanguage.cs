using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DTT_CSVDefinedLanguage : MonoBehaviour, DataToTextInterface {
    /**
     * Uses csv data in a format similar to backus naur form
     * with invalid branches progressively removed
     * and the remaining randomly selected from
     * where %example% are directly related to attrib keys
     * and {example} to the attrib[example] value
    **/

    public int maxElements = 10;
    public float alwaysIncludeThreshold = 0.8f;

    public TextAsset ta;
    private CSVDemangler lu;

    void Start() {
        lu = new CSVDemangler(ta.ToString());
    }

    public string getText(List<Description> data) {
        data.Sort((d1, d2) => d2.importance.CompareTo(d1.importance));

        List<string[]> t = lu.getData();
        return t[0][0] + "____" + t[0][1];

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
