using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCF_InVision : MonoBehaviour {
    /**
     * Player character feature - Vision Objects
     * Samples an entire area and gets all objects
    **/

    public GameObject accessibleScriptParent;
    private Object accessibleScript; //TODO

    public LayerMask interactionMask;

    private Vector3 rotateOffAxis = new Vector3(0, 45, 0);
    private float displacementOffCentre;
    public Vector3 size = new Vector3(10, 5, 10);

    void Update() {
        if(Input.GetAxis("Debug") == 1f) {
            trigger();
        }
    }

    void Start() {
        //accessibleScript = accessibleScriptParent.GetComponent<Object>();
        displacementOffCentre = Mathf.Sqrt(size.x * size.x + size.z * size.z)/2;
    }

    public void trigger() {
        //Debug.Log(displacementOffCentre);
        Vector3 angle = rotateOffAxis + transform.eulerAngles;
        Vector3 pos = transform.forward * displacementOffCentre + transform.position;

        Collider[] hitColliders = Physics.OverlapBox(pos, size / 2, Quaternion.Euler(angle), interactionMask);

        foreach(Collider c in hitColliders) {
            GOA_Describable obj = c.GetComponent<GOA_Describable>();
            Debug.Log(obj.objectName);
        }
    }

    //void OnDrawGizmos() {
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(transform.forward * displacementOffCentre + transform.position, size);
    //}
}
