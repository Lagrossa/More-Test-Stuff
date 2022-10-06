using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cammy : MonoBehaviour
{
    public GameObject toTrack;

    private void OnDrawGizmos()
    {
        transform.LookAt(toTrack.transform.position);
    }
}
