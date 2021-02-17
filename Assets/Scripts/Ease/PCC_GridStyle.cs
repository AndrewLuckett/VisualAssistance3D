using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCC_GridStyle : PCC_Default {
    /**
     * Player Character controller script that mimicks the movement style of
     * most first person shooter games however vision snaps to fixed angles
     * and the player moves on a grid
     * Minus:
     *     Jumping
     *     Momentum
     *     Gravity acceleration
     *     3d camera motions (x axis rotate only)
    **/

    public int angleSnaps = 8; //How many snaps in 360'
    public float gridSize = 0.5f; //How much the player jumps

    private float shadowAngle;
    private Vector3 shadowPosition;
    private float angleSnap;

    protected override void Start() {
        base.Start();
        shadowAngle = transform.eulerAngles.y;
        shadowPosition = transform.position;
        angleSnap = 360f / angleSnaps;
    }

    protected override void handleUpdate() {
        if(!controller.isGrounded) {
            controller.Move(new Vector3(0, -fallSpeed, 0));
        } //Crappy pseudo gravity

        movePlayer(Input.GetAxis("Vertical"));
        strafePlayer(Input.GetAxis("Horizontal"));

        float mouseHori = Input.GetAxis("Mouse X") * cameraSensitivity;
        turnPlayer(mouseHori);

        updatePlayer();
    }

    void movePlayer(float dir) {
        float delta = Time.deltaTime * dir * playerSpeed;
        shadowPosition += transform.forward * delta;
    }

    void strafePlayer(float dir) {
        float delta = Time.deltaTime * dir * playerSpeed;
        shadowPosition += transform.right * delta;
    }

    void turnPlayer(float raw) {
        shadowAngle += raw;
        while(shadowAngle > 360) {
            shadowAngle -= 360;
        }
        while(shadowAngle < 0) {
            shadowAngle += 360;
        }
    }

    void updatePlayer() {
        float angle = Mathf.Round(shadowAngle / angleSnap) * angleSnap;
        transform.eulerAngles = new Vector3(0, angle, 0);

        float x = Mathf.Round(shadowPosition.x / gridSize) * gridSize;
        float y = Mathf.Round(shadowPosition.y / gridSize) * gridSize;
        float z = Mathf.Round(shadowPosition.z / gridSize) * gridSize;

        controller.transform.position = new Vector3(x, y, z);
    }
}