using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Teleport objects that hit it to another location relative to the warp's center.
/// </summary>
public class Teleport : MonoBehaviour
{
    /// <summary>
    /// The destination of the warp.
    /// </summary>
    public Transform destination;

    /// <summary>
    /// Unity event handler.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider other) {        
        other.transform.position = destination.position + (other.transform.position - transform.position);
    }
}
