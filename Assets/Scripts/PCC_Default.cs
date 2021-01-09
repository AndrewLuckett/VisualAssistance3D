using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCC_Default : MonoBehaviour {
    /**
     * Player character controller - Default
    **/
    protected CharacterController controller;

    public float playerSpeed = 2.0f;
    public float fallSpeed = 2f;
    public float cameraSensitivity = 1f;

    protected virtual void Start() {
        controller = gameObject.GetComponent<CharacterController>();
        if(controller == null) {
            controller = gameObject.AddComponent<CharacterController>();
            controller.height = 2f;
            controller.center = new Vector3(0, 1, 0);
        }
    }

    void Update() {
        if(!controller.isGrounded) {
            controller.Move(new Vector3(0, -fallSpeed, 0));
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
