using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform LookAtObj;

    void Update()
    {
        Vector3 dirToObject = LookAtObj.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dirToObject);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1 * Time.deltaTime);
    }
}
