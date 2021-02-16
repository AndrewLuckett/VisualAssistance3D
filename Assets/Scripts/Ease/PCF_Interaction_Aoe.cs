using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCF_Interaction_Aoe : MonoBehaviour {
    /**
     * Player character feature - Soft Interaction
     * Samples an entire area rather than sending a single ray
    **/
    private float cooldownLeft = 0f;

    public LayerMask interactionMask;
    public float cooldown = 1f;
    public Vector3 rotateOffAxis = new Vector3(0, 45, 0);
    public float displacementOffCentre = 5f;
    public Vector3 size = new Vector3(10, 5, 10);

    public LayerMask visionBlockingMask; //The things that can block what we care about
    public float eyeHeight = 1.65f;

    void Start() {
    }

    void Update() {
        cooldownLeft -= Time.deltaTime;
        if(cooldownLeft <= 0 && Input.GetAxis("Interact") == 1f) {
            cooldownLeft = cooldown;

            attemptInteract();
        }
    }

    void attemptInteract() {
        Vector3 angle = rotateOffAxis + transform.eulerAngles;
        Vector3 pos = transform.forward * displacementOffCentre + transform.position;

        Collider[] hitColliders = Physics.OverlapBox(pos, size / 2, Quaternion.Euler(angle), interactionMask);

        Debug.Log("bing");
        foreach(Collider c in hitColliders) {
            Debug.Log("bong");
            //check if visible
            Vector3 posR = transform.position + new Vector3(0, eyeHeight, 0);
            Vector3 delta = c.transform.position - posR;
            Ray ray = new Ray(posR, delta);
            Debug.DrawRay(posR, delta, Color.red, 2f);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, delta.magnitude, visionBlockingMask)) {
                if(hit.collider == c) {
                    TriggerableInterface[] obj = c.GetComponents<TriggerableInterface>();
                    if(obj.Length > 0)
                        foreach(TriggerableInterface t in obj)
                            t.trigger();
                }
            }
        }
    }

    //void OnDrawGizmos() {
    //    Gizmos.color = Color.red;
    //    //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
    //    if(m_Started)
    //        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)

    //        Gizmos.DrawWireCube(transform.forward * displacementOffCentre + transform.position, size);
    //}
}
