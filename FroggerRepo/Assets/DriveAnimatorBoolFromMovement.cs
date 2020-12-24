using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveAnimatorBoolFromMovement : MonoBehaviour
{
    Vector3 lastPosition;
    public string walkingAnimatorParameter = "isWalking";
    public Animator animator;

    bool isMoving = false;
    private void Awake() {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        bool wasMoving = isMoving;

        isMoving = Vector3.Distance(transform.position, lastPosition) > 0.001f;
        lastPosition = transform.position;

        if (isMoving && !wasMoving) {
            animator.SetBool(walkingAnimatorParameter, true);
        } else if (!isMoving && wasMoving) {
            animator.SetBool(walkingAnimatorParameter, false);
        }

    }
}
