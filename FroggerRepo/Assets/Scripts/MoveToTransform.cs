using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveToTransform : MonoBehaviour
{
    public Transform follow;
    public float speed;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, follow.position, Time.deltaTime * speed);        
    }
}
