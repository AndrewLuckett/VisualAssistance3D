using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOA_Button : MonoBehaviour, TriggerableInterface {
    /**
    * Game object Attribute - Button
    * Distributor might be a better name
    **/
    private bool used = false;
    private TriggerableInterface[] triggers;

    public bool singleUse = false;
    public GameObject[] triggerObjects;

    void Start() {
        List<TriggerableInterface> t = new List<TriggerableInterface>();
        foreach(GameObject g in triggerObjects) {
            TriggerableInterface[] a = g.GetComponents<TriggerableInterface>();
            if(a.Length > 0)
                t.AddRange(a);
            else
                Debug.Log("Button loaded with GO with no triggerable script");
        }

        //Debug.Log(t.Count);
        triggers = t.ToArray();
    }

    public TriggerResponses trigger() {
        //Debug.Log(triggers.Length);
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