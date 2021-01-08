using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCC_WowStyle : MonoBehaviour {
    /**
     * Player Character controller script that mimicks the movement style of
     * world of warcraft
     * Minus:
     *     Jumping
     *     Momentum
     *     Gravity acceleration
     *     3d camera motions (y axis rotate only)
    **/

    private CharacterController controller;

    private Vector3 defaultCameraAngle;
    private float timeUntilCameraReset = 0f;
    private bool cameraSkewed = false;

    public float playerSpeed = 2.0f;
    public float rot = 30.0f; //Degree's per second
    public float fallSpeed = 2f;

    public GameObject cameraObject = null; //Not normally the camera itself
    //But instead the gameobject that the camera is parented to allowing for
    //swivel around centre
    public float cameraResettime = 1f; //One second
    public float cameraSensitivity = 1f;

    private void Start() {
        controller = gameObject.GetComponent<CharacterController>();
        defaultCameraAngle = cameraObject.transform.forward;
    }

    void Update() {
        if(!controller.isGrounded) {
            controller.Move(new Vector3(0, -fallSpeed, 0));
        }

        movePlayer(Input.GetAxis("Vertical"));
        turnPlayer(Input.GetAxis("Horizontal"));


        if(cameraSkewed) {
            timeUntilCameraReset -= Time.deltaTime;
            if(timeUntilCameraReset <= 0) {
                cameraObject.transform.forward = defaultCameraAngle;
                cameraSkewed = false;
            }
        }
        
        //TODO Mouse junk if holding rmb then fps controls
        //If holding lmb move just camera
    }

    void movePlayer(float dir) {
        float delta = Time.deltaTime * dir * playerSpeed;
        controller.Move(gameObject.transform.forward * delta);
    }

    void turnPlayer(float dir) {
        float delta = Time.deltaTime * dir * rot;
        gameObject.transform.eulerAngles += new Vector3(0, delta, 0);
    }

    void turnCamera(float raw) {
        cameraSkewed = true;
        timeUntilCameraReset = cameraResettime;

        float amount = raw * cameraSensitivity;
        cameraObject.transform.eulerAngles += new Vector3(0, amount, 0);
    }
}