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
    public float z;
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

            // TESTING
            //float zVal = Mathf.Tan(angRadians);
            //if (Mathf.Abs(zVal) > 1)
            //    zVal /= zVal;
            Vector3 point = new Vector3(xVal, 0, yVal);
            Handles.DrawWireArc(transform.position, Vector3.forward, (transform.position- trigger.transform.position).normalized, angThreshold, radius);
            if (angRadians < Mathf.Deg2Rad * angThreshold)
            {
                Gizmos.color = Color.cyan;
            }
            else
            {
                Gizmos.color = Color.red;
            }
            //Gizmos.DrawSphere(point, radius);
            Gizmos.DrawLine(transform.position, point);

        }
        
    }
}
