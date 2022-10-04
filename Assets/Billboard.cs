using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform LookAtObj;
    Vector3 dirToObject;
    void Update()
    {
        dirToObject = LookAtObj.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dirToObject);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1 * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, dirToObject + transform.position);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, LookAtObj.position);
    }
}
