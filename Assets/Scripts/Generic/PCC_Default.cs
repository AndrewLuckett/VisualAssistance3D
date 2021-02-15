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

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    protected virtual void Update() {
        //always updating, even when paused
        if(canProcessInput())
            handleUpdate();
    }

    protected virtual void handleUpdate() {
        //Update for when the user input can be processed
        if(!controller.isGrounded) {
            controller.Move(new Vector3(0, -fallSpeed, 0));
        } //Crappy pseudo gravity

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    public bool canProcessInput() {
        return Cursor.lockState == CursorLockMode.Locked;
    }

    public void setMouseSens(float v) {
        cameraSensitivity = v;
    }
}
