using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    public GameObject p0;
    public GameObject p1;
    public GameObject p2;
    [Range(0,1)]
    public float lengthAlong;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 p0top1 = p1.transform.position - p0.transform.position;
        Gizmos.DrawLine(p0.transform.position, p1.transform.position);
        p2.transform.position = p0.transform.position + lengthAlong * p0top1;
    }
}
