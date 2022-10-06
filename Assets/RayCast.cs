using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{


    void OnDrawGizmos()
    {
        Ray busby = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(busby, out hitInfo, 100f)){
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + busby.direction * 100f, Color.green);
        }
    }
}
