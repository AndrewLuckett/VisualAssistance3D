using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DTT_CSVDefinedLanguage : MonoBehaviour, DataToTextInterface {
    /**
     * Uses csv data in a format similar to backus naur form
     * with invalid branches progressively removed
     * and the remaining randomly selected from
     * where %example% are directly related to language keys
     * and !example! are directly related to language keys but
     * are dependent on an attrib key of the same name
     * and {example} to the attrib[example] value
    **/

    public int maxElements = 5;
    public float alwaysIncludeThreshold = 0.8f;

    public TextAsset ta;
    private CSVDemangler lu;
    private Dictionary<string, string[]> language;
    private Random rand;
    private string startKey = "sentence";

    void Start() {
        lu = new CSVDemangler(ta.ToString());
        language = lu.getDataAsDict(0);
        rand = new Random();
    }

    public string getText(List<Description> data) {
        data.Sort((d1, d2) => d2.importance.CompareTo(d1.importance));
        //Put objects in importance order
        
        string outs = "";
        int sentences = 0;
        foreach(Description d in data) {
            if(sentences > maxElements && d.importance < alwaysIncludeThreshold) {
                break;
            }
            outs += generateSentence(d);
        }
        
        return outs;
    }

    private string generateSentence(Description data) {
        string ret = generationTree(data, startKey);
        if(ret == null)
            ret = "SENTENCE GENERATOR FAILED";
        return ret;
    }

    private string generationTree(Description data, string currentKey) {
        //Recursive generation taking randomly selected branches
        //Returns null if branch is dead
        //If a child instance returns null the parent select another branch
        //If all branches are dead, return null
        string ret = "";
        List<string> options = new List<string>(language[currentKey]);
        return null;
    }
}
