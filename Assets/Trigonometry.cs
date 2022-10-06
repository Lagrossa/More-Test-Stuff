using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigonometry : MonoBehaviour
{
    public GameObject trigger;
    public float TAU = 6.28f; // Divide by X to mimic Unit Circle
    public int dots = 16;
    public float radius = 1;
    public float z;
    public float leniency;
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
            if (Vector3.Dot(trigger.transform.position.normalized, point.normalized) > leniency &&
                (trigger.transform.position - transform.position).magnitude < radius)
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
