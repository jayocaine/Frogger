using UnityEngine;

/// <summary>
/// Move an object in one direction forever
/// </summary>
public class ContinousMovement : MonoBehaviour
{
    /// <summary>
    /// A direction vector (will be normalized)
    /// </summary>
    public Vector3 direction;

    /// <summary>
    /// The speed of the object in units per second.
    /// </summary>
    public float speed;

    private void Update() {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
