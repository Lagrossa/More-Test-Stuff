using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PlaneNormalizer : MonoBehaviour
{
    [Header("Drag and drop a new PLANE game object.")]
    [Tooltip("This is your 'base' that you will be building on top of.")]
    public GameObject plane;
    [Header("Keep at 5 unless Lain or Louanne tell you otherwise.")]
    public float planeSize = 5f;

    const float basePlane = 5f; // L/W/H of a plane in its 'raw' unedited form. DO NOT CHANGE
    private void OnDrawGizmos()
    {
        //normalize to planesize
        plane.transform.localScale = new Vector3(planeSize/ basePlane, planeSize/ basePlane, planeSize/ basePlane);

        //Plane visualizations
        // y Axis
        Gizmos.color = Color.green;
        Vector3 planeHeight = Vector3.up * planeSize;
        Gizmos.DrawLine(plane.transform.position, planeHeight + plane.transform.position);
        Handles.Label(new Vector3(planeHeight.x, planeHeight.y/2, planeHeight.z) + plane.transform.position,
            planeSize + "m tall");
        // x Axis
        Gizmos.color = Color.red;
        Vector3 planeLength = Vector3.right * planeSize;
        Gizmos.DrawLine(plane.transform.position, planeLength + plane.transform.position);
        Handles.Label(new Vector3(planeLength.x/2, planeLength.y, planeLength.z) + plane.transform.position,
            planeSize + "m long");
        // z Axis
        Gizmos.color = Color.blue;
        Vector3 planeWidth = Vector3.forward * planeSize;
        Gizmos.DrawLine(plane.transform.position, planeWidth + plane.transform.position);
        Handles.Label(new Vector3(planeWidth.x, planeWidth.y, planeWidth.z/2) + plane.transform.position,
            planeSize + "m wide");
    }

}
