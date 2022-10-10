using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTests : MonoBehaviour
{
    public float angleDeg;

    void OnDrawGizmos()
    {
        float xVal = Mathf.Cos(angleDeg);
        float yVal = Mathf.Sin(angleDeg);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(xVal, yVal, 0));
        Gizmos.color = Color.red;

        Gizmos.color = Color.green;

        Gizmos.color = Color.yellow;
    }
}
