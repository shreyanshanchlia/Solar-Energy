using UnityEngine;

public static class GridSnapExtension
{
    /// <summary>
    /// Snaps to the nearest grid point
    /// </summary>
    /// <param name="toSnapObject">transform reference of object to snap.</param>
    /// <param name="snappingDelta">the grid size to which snapping is to be done.</param>
    /// <param name="snapZ">Should snapping be done in z axis.</param>
    public static void Snap(this Transform toSnapObject, float snappingDelta, bool snapZ = false)
    {
        Vector3 snapPosition = toSnapObject.position / snappingDelta;
        snapPosition.x = Mathf.RoundToInt(snapPosition.x) * snappingDelta;
        snapPosition.y = Mathf.RoundToInt(snapPosition.y) * snappingDelta;
        if(snapZ) snapPosition.z = Mathf.RoundToInt(snapPosition.z) * snappingDelta;

        toSnapObject.position = snapPosition;
    }
}
