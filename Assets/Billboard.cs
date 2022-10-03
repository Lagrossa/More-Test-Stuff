using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform LookAtObj;
    Vector3 dirToObject;
    public float rotSpeed;

    private void OnDrawGizmos()
    {
        dirToObject = LookAtObj.transform.position - transform.position;
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, dirToObject + transform.position);

        Quaternion rot = Quaternion.LookRotation(dirToObject.normalized);

        //Lock X-Degree & Z Rotation
        rot.x = 0;
        rot.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotSpeed * Time.deltaTime);
    }
}
