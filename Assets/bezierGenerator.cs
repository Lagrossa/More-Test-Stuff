using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bezierGenerator : MonoBehaviour
{
    public Vector3 trueMid;
    public List<GameObject> points = new List<GameObject>();
    public bool on;
    public GameObject folder;
    List<GameObject> gOHolder = new List<GameObject>();
    [Range(0,1)]
    public float lerp;
    private void OnDrawGizmos()
    {
        if (on)
        {
            GenerateCurve(points);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(trueMid, 0.25f);

        Gizmos.DrawSphere((points[1].transform.position-points[0].transform.position)*lerp, .05f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GenerateCurve(List<GameObject> list)
    {
        List<GameObject> midPoints = new List<GameObject>();
        if (list.Count <= 1)
        {
            trueMid = list[0].transform.position;
            for(int x = 0; x< gOHolder.Count; x++)
            {
                GameObject destroyTheChild = gOHolder[x];
                GameObject.DestroyImmediate(destroyTheChild);
            }
            return trueMid;
        }
        else
        {
            //for ABC return AB/2 BC/2
            for(int x = 0; x < list.Count-1; x++)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawLine(points[x].transform.position, points[x + 1].transform.position);
                Vector3 dist = list[x + 1].transform.position - list[x].transform.position;
                GameObject midPoint = new GameObject();
                midPoint.transform.position = dist * lerp;
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(list[x].transform.position, list[x].transform.position+dist);
                midPoints.Add(midPoint);
                gOHolder.Add(midPoint);
                midPoint.transform.SetParent(folder.transform);
                Gizmos.DrawSphere(midPoint.transform.position, .15f);
            }
            //Debug.Log($"New Array size: {midPoints.Count}");
            return GenerateCurve(midPoints);
        }
       
    }
}
