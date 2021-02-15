using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PCF_InVision : MonoBehaviour, AccessibleInterface {
    /**
     * Player character feature - Vision Objects
     * Samples an entire area and gets all objects
    **/
    public LayerMask visibleMask; //The things we care about
    public LayerMask visionBlockingMask; //The things that can block what we care about

    private Vector3 rotateOffAxis = new Vector3(0, 45, 0);
    private float displacementOffCentre;
    public Vector3 size = new Vector3(10, 5, 10);

    void Start() {
        displacementOffCentre = Mathf.Sqrt(size.x * size.x + size.z * size.z)/2;
    }

    public List<Description> getDescribables() {
        List<Description> outl = new List<Description>();

        Vector3 angle = rotateOffAxis + transform.eulerAngles;
        Vector3 pos = transform.forward * displacementOffCentre + transform.position;

        Collider[] hitColliders = Physics.OverlapBox(pos, size / 2, Quaternion.Euler(angle), visibleMask);

        foreach(Collider c in hitColliders) {
            //TODO raycast if actually visible
            GOA_Describable obj = c.GetComponent<GOA_Describable>();
            //Debug.Log(obj.objectName);
            outl.Add(obj.getDescription(transform));
        }

        return outl;
    }

    //void OnDrawGizmos() {
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(transform.forward * displacementOffCentre + transform.position, size);
    //}
}
