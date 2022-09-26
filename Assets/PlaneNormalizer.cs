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
        Gizmos.color = Color.green;
        Vector3 planeHeight = (Vector3.up * planeSize + plane.transform.position);
        Gizmos.DrawLine(plane.transform.position, planeHeight);
        Handles.color = Color.green;
        Handles.Label(new Vector3(planeHeight.x, planeHeight.y/2, planeHeight.z),
            planeSize + "m tall");
        Handles.color = Color.blue;
    }

}
