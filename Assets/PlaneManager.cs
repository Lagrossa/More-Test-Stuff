using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlaneManager : MonoBehaviour
{
    [Range(0,20)]
    public int setMaxRow;
    public static int maxRow = 5;
    [Range(0, 20)]
    public int setMaxCol;
    public static int maxCol = 5;
    [SerializeField]
    public GameObject[,] tileSet = new GameObject[maxRow,maxCol];
    public GameObject tile;
    public bool building;
    public GameObject folder;

    public bool reset;
    void OnDrawGizmos()
    {
        if (reset)
        {
            tileSet = new GameObject[maxRow, maxCol];
            Transform.DestroyImmediate(folder);
            folder = new GameObject();
        }


        //Populate Array while building
        if (!building)
        {
            return;
        }
        reset = true;
        maxRow = setMaxRow;
        maxCol = setMaxCol;
        tileSet = new GameObject[maxRow, maxCol];
        for (int x = 0; x < setMaxRow; x++)
        {
            for(int y = 0; y < setMaxCol; y++)
            {
                GameObject thisTile = GameObject.Instantiate(tile);
                thisTile.transform.position = new Vector3(2*x * PlaneNormalizer.planeSize, 0, 2*y * PlaneNormalizer.planeSize);
                GameObject.DestroyImmediate(tileSet[x, y]);
                tileSet[x, y] = thisTile;
                thisTile.transform.SetParent(folder.transform);
            }
        }
        reset = false;

    }
}
