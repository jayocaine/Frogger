using UnityEngine;


/// <summary>
/// Custom physics and collision functions
/// </summary>
public static class CollissionUtility {

    /// <summary>
    /// Unused.  For storing overlap information
    /// </summary>
    private static Collider[] results = new Collider[1];

    /// <summary>
    /// Check if a point is within a collider
    /// </summary>
    /// <param name="p">The point to check</param>
    /// <param name="layerMask">The layer mask to check, default is all layers.</param>
    /// <returns>Whether the point is inside another collider or not</returns>
    public static bool PointCollidesWithWorld(Vector3 p, int layerMask = ~0 ) {
        return Physics.OverlapSphereNonAlloc(p, 0,results) > 0;
    }
}