using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigonometry : MonoBehaviour
{
    const float TAU = 6.28f;
    public int dots = 16;
    public float radius = 1;
    public float z;
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

            Gizmos.color = Color.cyan;
            Vector3 point = new Vector3(xVal, yVal, z);
            //Gizmos.DrawSphere(point, radius);
            Gizmos.DrawLine(transform.position, point);

        }
        
    }
}
