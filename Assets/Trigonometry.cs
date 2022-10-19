using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Trigonometry : MonoBehaviour
{
    public GameObject trigger;
    public float TAU = 6.28f; // Divide by X to mimic Unit Circle
    public int dots = 16;
    public float radius = 1;
    public float thickness = 1f;
    public float z;
    public float dotProduct;
    [Range(0,360)]
    public float angThreshold;
    void OnDrawGizmos()
    {
        for(int x = 0; x < dots; x++)
        {
            float t = x / (float)dots;
            float angRadians = TAU * t;
            float xVal = Mathf.Cos(angRadians);
            float yVal = Mathf.Sin(angRadians);
            Vector3 triggerTransform = trigger.transform.position;
            Vector3 point = new Vector3(xVal, 0, yVal);
            Handles.DrawWireArc(transform.position, Vector3.up, (triggerTransform - transform.position).normalized, -angThreshold, radius, thickness);

            Gizmos.color = angRadians < Mathf.Deg2Rad * angThreshold ? Color.cyan : Color.red;
            Gizmos.DrawLine(transform.position, point);
            //

            //Draw to sphere color determined by dotproduct
            dotProduct = Vector3.Dot(transform.right, triggerTransform-transform.position);
            Gizmos.color = new Color(1-dotProduct, dotProduct, 0);
            Gizmos.DrawLine(transform.position, transform.position + triggerTransform);

        }
        
    }
}
