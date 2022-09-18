using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class bezierGenerator : MonoBehaviour
{
    [Range(0f, 1f)]
    public float lerp;
    public Vector3 trueMid;
    public List<GameObject> points = new List<GameObject>();
    public bool on;
    
    public GameObject folder;
    List<GameObject> gOHolder = new List<GameObject>();
    public LineRenderer lineRender;
    [Range(.02f, 1f)]
    public float resolution = .05f;
    private void OnDrawGizmos()
    {
        if (on)
        {
            GenerateCurve(points);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(trueMid, 0.25f);
    
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
                //Gizmos.DrawLine(points[x].transform.position, points[x + 1].transform.position);
                Vector3 dist = list[x + 1].transform.position - list[x].transform.position;
                GameObject midPoint = new GameObject();
                midPoint.transform.position = list[x].transform.position + dist * lerp;
                estimateCurve(list);
                Gizmos.color = Color.cyan;
                //Gizmos.DrawLine(list[x].transform.position, list[x].transform.position+dist);
                Gizmos.DrawLine(midPoint.transform.position, trueMid);
                midPoints.Add(midPoint);
                gOHolder.Add(midPoint);
                midPoint.transform.SetParent(folder.transform);
                Gizmos.DrawSphere(midPoint.transform.position, .15f);
                lineRender.positionCount = midPoints.Count;
                lineRender.SetPosition(x, midPoints[x].transform.position);
            }
            //estimateCurve(midPoints);
            //Debug.Log($"New Array size: {midPoints.Count}");
            return GenerateCurve(midPoints);
        }
       
    }

    void estimateCurve(List<GameObject> list)
    {
        int y = 1;
        for (int x = 0; x < list.Count - 2; x++)
        {
            for (float t = 0; t < 1; t += resolution)
            {
                Gizmos.DrawLine(Vector3.Lerp(list[x].transform.position,
                    list[x + y].transform.position, t),
                    Vector3.Lerp(list[x + y].transform.position,
                    list[x + y + 1].transform.position, t));
            }
        }
    }
}
