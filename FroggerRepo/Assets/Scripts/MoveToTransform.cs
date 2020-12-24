using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTransform : MonoBehaviour
{
    public Transform follow;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, follow.position, Time.deltaTime * speed);
    }
}
