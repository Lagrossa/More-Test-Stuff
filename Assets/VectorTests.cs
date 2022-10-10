using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTests : MonoBehaviour
{
    [Range(0,360)]
    public int angleDeg;

    void OnDrawGizmos()
    {
        float radAng = angleDeg * Mathf.Deg2Rad;
        float xVal = Mathf.Cos(radAng);
        float yVal = Mathf.Sin(radAng);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(xVal, yVal, 0));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-xVal, yVal, 0));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-xVal, -yVal, 0));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(xVal, -yVal, 0));

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-yVal, xVal, 0));
        Gizmos.color = Color.magenta;
        Gizmos.color = Color.white;
        Gizmos.color = Color.grey;
    }
}
