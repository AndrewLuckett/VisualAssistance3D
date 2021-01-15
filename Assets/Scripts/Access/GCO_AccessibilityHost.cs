using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GCO_AccessibilityHost : MonoBehaviour {
    /**
     * Game control object - Accessibility host
     * Manages all accessibility data
    **/

    public GameObject[] onEventParent;
    //Unity has a hard time serialising interfaces
    private AccessibleInterface[] onEvent;
    public float timeout = 2f; //Seconds
    private float cooldown = 0f;

    public Text text;

    private List<Description> queued = new List<Description>();
    private DataToTextInterface dtt;

    private void Start() {
        List<AccessibleInterface> ai = new List<AccessibleInterface>();
        foreach(GameObject go in onEventParent) {
            ai.AddRange(go.GetComponents<AccessibleInterface>());
        }
        onEvent = ai.ToArray();
        onEventParent = null;
        dtt = GetComponent<DataToTextInterface>();
    }

    void LateUpdate() {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0f) {
            cooldown = timeout;

            accessEvent();
            string t = dtt.getText(queued);
            text.text = t;
            //Debug.Log(t);
            queued.Clear();
        }
    }

    void accessEvent() {
        foreach(AccessibleInterface ai in onEvent) {
            queued.AddRange(ai.getDescribables());
        }
    }

    public void queueDescription(Description d) {
        queued.Add(d);
    }
}
