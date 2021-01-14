using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCC_WowStyle : PCC_Default {
    /**
     * Player Character controller script that mimicks the movement style of
     * world of warcraft
     * Minus:
     *     Jumping
     *     Momentum
     *     Gravity acceleration
     *     3d camera motions (y axis rotate only)
    **/
    private Quaternion defaultCameraAngle;
    private float timeUntilCameraReset = 0f;
    private bool cameraSkewed = false;

    public float rot = 30.0f; //Degree's per second

    public GameObject cameraObject = null; //Not normally the camera itself
    //But instead the gameobject that the camera is parented to allowing for
    //swivel around centre
    public float cameraResettime = 1f; //One second

    protected override void Start() {
        base.Start();
        defaultCameraAngle = cameraObject.transform.localRotation;
    }

    protected override void handleUpdate() {
        movePlayer(Input.GetAxis("Vertical"));
        turnPlayer(Input.GetAxis("Horizontal") * Time.deltaTime * rot);

        if(cameraSkewed) {
            timeUntilCameraReset -= Time.deltaTime;
            if(timeUntilCameraReset <= 0) {
                cameraObject.transform.localRotation = defaultCameraAngle;
                cameraSkewed = false;
            }
        }

        float mouseHori = Input.GetAxis("Mouse X") * cameraSensitivity;
        if(Input.GetAxis("RMB") == 1f) {
            turnPlayer(mouseHori);
        } else if(Input.GetAxis("LMB") == 1f) {
            turnCamera(mouseHori);
        }
    }

    void movePlayer(float dir) {
        float delta = Time.deltaTime * dir * playerSpeed;
        controller.Move(gameObject.transform.forward * delta);
    }

    void turnPlayer(float raw) {
        gameObject.transform.eulerAngles += new Vector3(0, raw, 0);
    }

    void turnCamera(float raw) {
        cameraSkewed = true;
        timeUntilCameraReset = cameraResettime;

        cameraObject.transform.eulerAngles += new Vector3(0, raw, 0);
    }
}