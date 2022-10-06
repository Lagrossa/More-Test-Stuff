using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform LookAtObj;
    Vector3 dirToObject;
    public float rotSpeed;
    public bool rotX;
    public bool rotY;
    public bool rotZ;
    public float dotOfVectors; //Debugging purposes lol
    private void OnDrawGizmos()
    {
        dirToObject = LookAtObj.transform.position - transform.position;
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, dirToObject + transform.position);

        Quaternion rot = Quaternion.LookRotation(dirToObject.normalized);

        //Lock X-Degree & Z-Degree Rotation
        if (!rotX)
        {
            rot.x = 0;
        }
        if (!rotY)
        {
            rot.y = 0;
        }
        if (!rotZ)
        {
            rot.z = 0;
        }
        //Quaternion parentNormal = Quaternion.LookRotation(transform.parent.up);
        //dotOfVectors = Vector3.Dot(dirToObject.normalized, transform.parent.up);
        //if (Mathf.Abs(dotOfVectors) >= .5)
        //{
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, parentNormal, rotSpeed * Time.deltaTime);
        //}


        //DRAW NORMALS SO I CAN FUCKING DEBUG

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.parent.position, transform.parent.up + transform.parent.position);
        UnityEditor.SceneView.RepaintAll();
    }
}
