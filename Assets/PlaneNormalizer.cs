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

    private void OnDrawGizmos()
    {
        plane.transform.localScale = new Vector3(planeSize, planeSize, planeSize);

        //Plane visualizations
        // y Axis
        Gizmos.color = Color.green;
        Vector3 planeHeight = Vector3.up * planeSize + plane.transform.position;
        Gizmos.DrawLine(plane.transform.position, planeHeight);
        Handles.Label(new Vector3(planeHeight.x, planeHeight.y/2, planeHeight.z),
            planeSize + "m tall");
        // x Axis
        Gizmos.color = Color.red;
        Vector3 planeLength = Vector3.right * planeSize + plane.transform.position;
        Gizmos.DrawLine(plane.transform.position, planeLength);
        Handles.Label(new Vector3(planeLength.x/2, planeLength.y, planeLength.z),
            planeSize + "m long");
        // z Axis
        Gizmos.color = Color.blue;
        Vector3 planeWidth = Vector3.forward * planeSize + plane.transform.position;
        Gizmos.DrawLine(plane.transform.position, planeWidth);
        Handles.Label(new Vector3(planeWidth.x / 2, planeWidth.y, planeWidth.z),
            planeSize + "m wide");
    }

}
