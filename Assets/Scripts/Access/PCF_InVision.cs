using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PCF_InVision : MonoBehaviour, AccessibleInterface {
    /**
     * Player character feature - Vision Objects
     * Samples an entire area and gets all objects
     * Warning player collider can interfere with visible checks if part of
     * blocking layer types
    **/
    public LayerMask visibleMask; //The things we care about
    public LayerMask visionBlockingMask; //The things that can block what we care about

    private Vector3 rotateOffAxis = new Vector3(0, 45, 0);
    private float displacementOffCentre;
    public Vector3 size = new Vector3(10, 5, 10);
    public float eyeHeight = 0.65f;

    void Start() {
        displacementOffCentre = Mathf.Sqrt(size.x * size.x + size.z * size.z) / 2;
    }

    public List<Description> getDescribables() {
        List<Description> outl = new List<Description>();

        Vector3 angle = rotateOffAxis + transform.eulerAngles;
        Vector3 pos = transform.forward * displacementOffCentre + transform.position;

        Collider[] hitColliders = Physics.OverlapBox(pos, size / 2, Quaternion.Euler(angle), visibleMask);

        //for each object in range
        foreach(Collider c in hitColliders) {
            //check if visible
            Vector3 posR = transform.position + new Vector3(0, eyeHeight, 0);
            Vector3 delta = c.transform.position - posR;
            Ray ray = new Ray(posR, delta);
            Debug.DrawRay(posR, delta, Color.white, 1f);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, delta.magnitude, visionBlockingMask)) {
                if(hit.collider == c) {
                    GOA_Describable obj = c.GetComponent<GOA_Describable>();
                    outl.Add(obj.getDescription(transform));
                }
            }
        }
        return outl;
    }

    //void OnDrawGizmos() {
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(transform.forward * displacementOffCentre + transform.position, size);
    //}
}
