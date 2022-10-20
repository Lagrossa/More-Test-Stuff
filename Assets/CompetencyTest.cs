using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetencyTest : MonoBehaviour
{
    public int dots;
    const float TAU = 6.28f;
    private void OnDrawGizmos()
    {
        for(int x = 0; x < dots; x++)
        {
            float percentCircumference = (float)x / dots;
            float degRad = percentCircumference * TAU;
            Vector3 point = new Vector3(Mathf.Cos(degRad), Mathf.Sin(degRad), 0);
        }
}
