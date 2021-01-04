using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Collectable : MonoBehaviour
{
    public UnityEvent collect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            collect.Invoke();
        }
    }
}
