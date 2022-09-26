using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneNormalizer : MonoBehaviour
{
    [Tooltip("Drag and drop a new PLANE game object. This is your 'base' that you will be building on top of.")]
    public GameObject plane;
    float planeSize = 5f;
    private void OnDrawGizmos()
    {
        plane.transform.localScale = new Vector3(planeSize, planeSize, planeSize);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(plane.transform.position, Vector3.up * planeSize + plane.transform.position);
    }

}
