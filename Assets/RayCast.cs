using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    int x = 60;
    int rayfreq = 2;
    void OnDrawGizmos()
    {
        for (int y = 0; y < x / 2; y += rayfreq)
        {
            Ray busby = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(busby, out hitInfo, 100f))
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                //Ricochet
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(hitInfo.point, Quaternion.FromToRotation(busby.direction, hitInfo.normal) * new Vector3(1, 1, 1));
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + busby.direction * 100f, Color.green);
            }
        }
    }
}
