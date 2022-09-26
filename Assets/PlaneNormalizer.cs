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
    [Header("On if you want visual guides on. Off if not.")]
    public bool visualGuides;
    const float basePlane = 5f; // L/W/H of a plane in its 'raw' unedited form. DO NOT CHANGE.

    [Header("Your 'node' sequence will determine where you connect. Enter exactly.")]
    [Range(0,2)]
    public int node1;
    [Range(0, 2)]
    public int node2;
    [Range(0, 2)]
    public int node3;
    [Range(0, 2)]
    public int node4;

    public float nodeRadius = .1f;
    private void OnDrawGizmos()
    {
        //normalize to plane size
        plane.transform.localScale = new Vector3(planeSize/ basePlane, planeSize/ basePlane, planeSize/ basePlane);

        //Plane visualizations
        if (visualGuides)
        {
            // y Axis
            Gizmos.color = Color.green;
            Vector3 planeHeight = Vector3.up * planeSize;
            Gizmos.DrawLine(plane.transform.position, planeHeight + plane.transform.position);
            Handles.Label(new Vector3(planeHeight.x, planeHeight.y / 2, planeHeight.z) + plane.transform.position,
                planeSize + "m tall");
            // x Axis
            Gizmos.color = Color.red;
            Vector3 planeLength = Vector3.right * planeSize;
            Gizmos.DrawLine(plane.transform.position, planeLength + plane.transform.position);
            Handles.Label(new Vector3(planeLength.x / 2, planeLength.y, planeLength.z) + plane.transform.position,
                planeSize + "m long");
            // z Axis
            Gizmos.color = Color.blue;
            Vector3 planeWidth = Vector3.forward * planeSize;
            Gizmos.DrawLine(plane.transform.position, planeWidth + plane.transform.position);
            Handles.Label(new Vector3(planeWidth.x, planeWidth.y, planeWidth.z / 2) + plane.transform.position,
                planeSize + "m wide");

            //Connection Nodes
            Vector3 nodeV1 = planeWidth + plane.transform.position; //+w,
            Vector3 nodeV2 = planeLength + plane.transform.position;//+l,
            Vector3 nodeV3 = (-planeWidth + plane.transform.position); //-w
            Vector3 nodeV4 = (-planeLength + plane.transform.position); //-l

            // Node 1
            Gizmos.color = NodeToColor(node1);
            Gizmos.DrawSphere(nodeV1, nodeRadius);
            // Node 2
            Gizmos.color = NodeToColor(node2);
            Gizmos.DrawSphere(nodeV2, nodeRadius);
            // Node 3
            Gizmos.color = NodeToColor(node3);
            Gizmos.DrawSphere(nodeV3, nodeRadius);
            // Node 4
            Gizmos.color = NodeToColor(node4);
            Gizmos.DrawSphere(nodeV4, nodeRadius);
        }
    }

    Color NodeToColor(int nodeNum) => nodeNum switch
    {
        0 => Color.red,
        1 => Color.green,
        2 => Color.blue,
        _ => Color.grey, //Literally, how do you do this. Like if it is EVER grey you fucked up so badly :(
    };
}
