using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveToTransform : MonoBehaviour
{
    public Transform follow;
    public float speed;
    public string walkingAnimatorParameter = "isWalking";

    public Animator animator;

    bool isMoving = false;
    // Update is called once per frame
    void Update()
    {
        bool wasMoving = isMoving;

        isMoving = Vector3.Distance(transform.position, follow.position) > 0.001f;
        
        if ( isMoving && !wasMoving) {
            animator.SetBool(walkingAnimatorParameter, true);
        } else if ( !isMoving && wasMoving) {
            animator.SetBool(walkingAnimatorParameter, false);
        }

        transform.position = Vector3.MoveTowards(transform.position, follow.position, Time.deltaTime * speed);
        
    }
}
