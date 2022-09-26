using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneNormalizer : MonoBehaviour
{
    [Tooltip("Drag and drop a new PLANE game object. This is your 'base' that you will be building on top of.")]
    public GameObject plane;

    private void OnDrawGizmos()
    {
        plane.transform.localScale = new Vector3(10, 10, 10);
    }

}
