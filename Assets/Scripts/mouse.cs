using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class mouse : MonoBehaviour
{
    void OnDrawGizmos()
    {
       
        transform.position = Camera.main.ScreenToWorldPoint(GUIUtility.GUIToScreenPoint(new Vector2(
            Event.current.mousePosition.x,
          Camera.main.pixelHeight-Event.current.mousePosition.y)));

        UnityEditor.SceneView.RepaintAll();
    }

    void OnSceneGUI(SceneView sceneView)
    {
        Vector3 mousePosition = Event.current.mousePosition;
        mousePosition.y = sceneView.camera.pixelHeight - mousePosition.y;
        mousePosition = sceneView.camera.ScreenToWorldPoint(mousePosition);
        mousePosition.y = -mousePosition.y;

        transform.position = mousePosition;
}
}
