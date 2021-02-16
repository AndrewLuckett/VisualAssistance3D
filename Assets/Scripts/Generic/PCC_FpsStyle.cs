using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCC_FpsStyle : PCC_Default {
    /**
     * Player Character controller script that mimicks the movement style of
     * most first person shooter games
     * Minus:
     *     Jumping
     *     Momentum
     *     Gravity acceleration
     *     3d camera motions (x axis rotate only)
    **/

    protected override void handleUpdate() {
        if(!controller.isGrounded) {
            controller.Move(new Vector3(0, -fallSpeed, 0));
        } //Crappy pseudo gravity

        movePlayer(Input.GetAxis("Vertical"));
        strafePlayer(Input.GetAxis("Horizontal"));

        float mouseHori = Input.GetAxis("Mouse X") * cameraSensitivity;
        turnPlayer(mouseHori);
    }

    void movePlayer(float dir) {
        float delta = Time.deltaTime * dir * playerSpeed;
        controller.Move(transform.forward * delta);
    }

    void strafePlayer(float dir) {
        float delta = Time.deltaTime * dir * playerSpeed;
        controller.Move(transform.right * delta);
    }

    void turnPlayer(float raw) {
        transform.eulerAngles += new Vector3(0, raw, 0);
    }
}