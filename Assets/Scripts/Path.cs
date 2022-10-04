using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Vector2 editorMousePos;
    public GameObject nodeBase;
    public List<GameObject> test = new();
    private void OnDrawGizmos()
    {
       
        editorMousePos = Camera.main.ScreenToWorldPoint(GUIUtility.GUIToScreenPoint(new Vector2(Event.current.mousePosition.x, -Event.current.mousePosition.y)));
        if(Event.current.button == 1)
        {
            GameObject node = Instantiate<GameObject>(nodeBase);
            test.Add(node);
            node.transform.position = editorMousePos;
        }
    }
}
