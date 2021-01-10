using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOA_Button : MonoBehaviour, GOA_Triggerable {
    /**
    * Game object Attribute - Button
    * Distributor might be a better name
    **/
    private bool used = false;
    private GOA_Triggerable[] triggers;

    public bool singleUse = false;
    public GameObject[] triggerObjects;

    void Start() {
        List<GOA_Triggerable> t = new List<GOA_Triggerable>();
        foreach(GameObject g in triggerObjects) {
            GOA_Triggerable[] a = g.GetComponents<GOA_Triggerable>();
            if(a.Length > 0)
                t.AddRange(a);
            else
                Debug.Log("Button loaded with GO with no triggerable script");
        }

        Debug.Log(t.Count);
        triggers = t.ToArray();
    }

    public TriggerResponses trigger() {
        Debug.Log(triggers.Length);
        if(used && singleUse)
            return TriggerResponses.normalNothing;

        for(int i = 0; i < triggers.Length; i++)
            if(triggers[i] != null)
                if(triggers[i].trigger() == TriggerResponses.died)
                    triggers[i] = null;

        used = true;
        return TriggerResponses.normal;
    }
}