using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGridSystemXYZ : MonoBehaviour
{
    public int zRows;
    public int xRows;
    public int yRows;

    public float gridSize = 1;
    public MyGridXZ[,] myGrid = new MyGridXZ[0, 0];
    float Xoffset, Zoffset, Yoffset;

    private void Awake()
    {
        myGrid = new MyGridXZ[zRows, xRows];
        Xoffset = transform.position.x - ((xRows / 2) * gridSize);
        Zoffset = transform.position.z - ((zRows / 2) * gridSize);
        Yoffset = transform.position.y - ((yRows / 2) * gridSize);
        GenerateGridMap();
    }


    public void GenerateGridMap()
    {
        for (int i = 0; i < zRows; i++)
        {
            for (int k = 0; k < xRows; k++)
            {
                myGrid[i, k] = new MyGridXZ(Xoffset + (k * gridSize) + gridSize / 2, 0, Zoffset + (i * gridSize) + gridSize / 2, new Vector3(k, 0, i));
            }
        }

    }

    public MyGridXZ GetGrid(Vector3 gridPos)
    {
        if (gridPos.x >= xRows)
        {
            gridPos.x = xRows - 1;
        }
        else if (gridPos.x < 0)
        {
            gridPos.x = 0;
        }

        if (gridPos.z >= zRows)
        {
            gridPos.z = zRows - 1;
        }
        else if (gridPos.z < 0)
        {
            gridPos.z = 0;
        }

        MyGridXZ newGrid = myGrid[(int)gridPos.z, (int)gridPos.x];

        return newGrid;
    }

    public MyGridXZ GetCurrentGridInfinitly(ref Vector3 pos)
    {
        if (pos.x >= xRows)
        {
            pos.x = pos.x % xRows;
        }
        else if (pos.x < 0)
        {
            pos.x += xRows;
        }

        if (pos.z >= zRows)
        {
            pos.z = pos.z % zRows;
        }
        else if (pos.z < 0)
        {
            pos.z += zRows;
        }

        MyGridXZ newGrid = myGrid[(int)pos.z, (int)pos.x];

        return newGrid;
    }

    public Vector3 WorldPosToGridPos(Vector3 worldPos)
    {

        Vector3 gridPos = new Vector3((int)(((worldPos.x - (Xoffset) - gridSize / 2)) / gridSize), 0, (int)(((worldPos.z - (Zoffset) - gridSize / 2)) / gridSize));
        return gridPos;
    }

    public MyGridXZ FindGridAccordingToWorldPos(Vector3 worldPos)
    {
        Vector3 gridPos = new Vector3((int)(((worldPos.x - (Xoffset) - gridSize / 2)) / gridSize), 0, (int)(((worldPos.z - (Zoffset) - gridSize / 2)) / gridSize));
        return GetGrid(gridPos);
    }

    public void PlaceSolidObj_Infinitly(Vector3 pos, GameObject obj, string tag)
    {
        if (pos.x >= xRows)
        {
            pos.x = pos.x % xRows;
        }
        else if (pos.x < 0)
        {
            pos.x += xRows;
        }

        if (pos.z >= zRows)
        {
            pos.z = pos.z % zRows;
        }
        else if (pos.z < 0)
        {
            pos.z += zRows;
        }

        MyGridXZ newGrid = myGrid[(int)pos.z, (int)pos.x];

        newGrid.placedObj = obj;
        newGrid.placedObjTag = tag;
        obj.transform.position = newGrid.worldPosition;
    }
    public void PlaceSolidObj_Infinitly(Vector3 pos, float yOffset, GameObject obj, string tag)
    {
        if (pos.x >= xRows)
        {
            pos.x = pos.x % xRows;
        }
        else if (pos.x < 0)
        {
            pos.x += xRows;
        }

        if (pos.z >= zRows)
        {
            pos.z = pos.z % zRows;
        }
        else if (pos.z < 0)
        {
            pos.z += zRows;
        }

        MyGridXZ newGrid = myGrid[(int)pos.z, (int)pos.x];
        newGrid.worldPosition.y = yOffset;
        newGrid.placedObj = obj;
        newGrid.placedObjTag = tag;
        obj.transform.position = newGrid.worldPosition;
        newGrid.worldPosition.y = 0;
    }

    public void RemoveSolidObject_Infinitly(Vector3 pos)
    {
        if (pos.x >= xRows)
        {
            pos.x = pos.x % xRows;
        }
        else if (pos.x < 0)
        {
            pos.x += xRows;
        }

        if (pos.z >= zRows)
        {
            pos.z = pos.z % zRows;
        }
        else if (pos.z < 0)
        {
            pos.z += zRows;
        }

        MyGridXZ newGrid = myGrid[(int)pos.z, (int)pos.x];
        newGrid.worldPosition.y = 0;
        newGrid.placedObjTag = null;
        newGrid.placedObj = null;
    }

    #region Limited Area Methods

    public void PlaceSolidObj_Limited(Vector3 pos, GameObject obj, string tag)
    {
        if (pos.x >= xRows)
        {
            pos.x = xRows - 1;
        }
        else if (pos.x < 0)
        {
            pos.x = 0;
        }

        if (pos.z >= zRows)
        {
            pos.z = zRows - 1;
        }
        else if (pos.z < 0)
        {
            pos.z = 0;
        }

        MyGridXZ newGrid = myGrid[(int)pos.z, (int)pos.x];

        newGrid.placedObj = obj;
        newGrid.placedObjTag = tag;
        newGrid.openGrid = false;

    }

    public void PlaceUnsolidObj_Limited(Vector3 pos, GameObject obj, string tag)
    {
        if (pos.x >= xRows)
        {
            pos.x = xRows - 1;
        }
        else if (pos.x < 0)
        {
            pos.x = 0;
        }

        if (pos.z >= zRows)
        {
            pos.z = zRows - 1;
        }
        else if (pos.z < 0)
        {
            pos.z = 0;
        }

        MyGridXZ newGrid = myGrid[(int)pos.z, (int)pos.x];
        newGrid.placedUnsolidObj = obj;
        newGrid.placedUnsolidObjTag = tag;
    }

    public void RemoveSolidObject_Limited(Vector3 pos)
    {
        if (pos.x >= xRows)
        {
            pos.x = xRows - 1;
        }
        else if (pos.x < 0)
        {
            pos.x = 0;
        }

        if (pos.z >= zRows)
        {
            pos.z = zRows - 1;
        }
        else if (pos.z < 0)
        {
            pos.z = 0;
        }

        MyGridXZ newGrid = myGrid[(int)pos.z, (int)pos.x];
        newGrid.worldPosition.y = 0;
        newGrid.placedObjTag = null;
        newGrid.placedObj = null;
        newGrid.openGrid = true;
    }

    public void RemoveUnsolidObject_Limited(Vector3 pos)
    {
        if (pos.x >= xRows)
        {
            pos.x = xRows - 1;
        }
        else if (pos.x < 0)
        {
            pos.x = 0;
        }

        if (pos.z >= zRows)
        {
            pos.z = zRows - 1;
        }
        else if (pos.z < 0)
        {
            pos.z = 0;
        }

        MyGridXZ newGrid = myGrid[(int)pos.z, (int)pos.x];
        newGrid.worldPosition.y = 0;
        newGrid.placedUnsolidObjTag = null;
        newGrid.placedUnsolidObj = null;
    }

    #endregion



    private void OnDrawGizmos()
    {

        Xoffset = transform.position.x - ((xRows / 2) * gridSize);
        Zoffset = transform.position.z - ((zRows / 2) * gridSize);
        Yoffset = transform.position.y;

        for (int j=0; j <= yRows; j++)
        {
            for (int i = 0; i <= zRows; i++)
            {
                for (int k = 0; k <= xRows; k++)
                {
                    Debug.DrawLine(new Vector3(Xoffset, Yoffset +(j*gridSize), Zoffset + (i * gridSize)), new Vector3(Xoffset + (xRows * gridSize), Yoffset + (j * gridSize), Zoffset + (i * gridSize)),Color.red); //x
                    Debug.DrawLine(new Vector3(Xoffset + (k * gridSize), Yoffset + (j * gridSize), Zoffset), new Vector3(Xoffset + (k * gridSize), Yoffset + (j * gridSize), Zoffset + (zRows * gridSize)),Color.green); //z
                    Debug.DrawLine(new Vector3(Xoffset + (k * gridSize), Yoffset, Zoffset + (i * gridSize)), new Vector3(Xoffset + (k * gridSize), Yoffset+(yRows*gridSize), Zoffset + (i * gridSize)),Color.blue); //for y axis lines
                }

            }
        }
        

    }
}

