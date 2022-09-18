using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bezierGenerator : MonoBehaviour
{
    public Vector3 trueMid;
    public List<GameObject> points = new List<GameObject>();

    private void OnDrawGizmos()
    {
        for (int x = 0; x < points.Count - 1; x++)
        {
            Gizmos.DrawLine(points[x].transform.position, points[x + 1].transform.position);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            GenerateCurve(points);
        }
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
            trueMid = list[1].transform.position;
            return list[1].transform.position;
        }
        else
        {
            //for ABC return AB/2 BC/2
            for(int x = 0; x < list.Count-1; x++)
            {
                Vector3 dist = list[x + 1].transform.position - list[x].transform.position;
                GameObject midPoint = new GameObject();
                midPoint.transform.position = dist / 2;
                midPoints.Add(midPoint);
                Gizmos.DrawSphere(midPoint.transform.position, .05f);
            }
            Debug.Log($"New Array size: {midPoints.Count}");
            return GenerateCurve(midPoints);
        }
       
    }
}
