using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCF_Interaction : MonoBehaviour {
    /**
     * Player character feature - Interaction
    **/
    private float cooldownLeft = 0f;

    public float cooldown = 1f;

    public Collider interactCollider;

    void Start() {

    }

    void Update() {
        cooldownLeft -= Time.deltaTime;
        if(cooldownLeft <= 0 && Input.GetAxis("Interact") == 1f) {
            cooldownLeft = cooldown;
            Debug.Log("i attempt");
        }
    }
}
