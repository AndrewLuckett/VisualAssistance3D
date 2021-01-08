using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCF_Interaction : MonoBehaviour {
    /**
     * Player character feature - Interaction
    **/
    private float cooldownLeft = 0f;

    public LayerMask interactionMask;
    public float cooldown = 1f;
    public float range = 3;
    public Vector3 rotateOffAxis = new Vector3(0, 45, 0);
    public Vector3 displacementOffCentre = new Vector3(0, 0, 0);

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
        Vector3 angle = Quaternion.Euler(rotateOffAxis) * gameObject.transform.forward;
        Vector3 pos = displacementOffCentre + gameObject.transform.position;
        Ray ray = new Ray(pos, angle);
        RaycastHit hit;

        //Debug.DrawRay(pos, angle, Color.white, 20f);

        if(Physics.Raycast(ray, out hit, range, interactionMask)) {
            //Debug.Log("Cast hit something");
            InteractableTemplate obj = hit.collider.GetComponent<InteractableTemplate>();
            if(obj != null) {
                obj.trigger();
            }
        }
    }
}
