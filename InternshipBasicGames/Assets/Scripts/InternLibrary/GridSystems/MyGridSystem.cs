using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGridSystem : MonoBehaviour
{
    // TODO column row yerine sizeX, sizeY tercih ediyorum daha az karisiyor ++
    public int sizeY;
    public int sizeX;
    public float gridSize = 1;
    public MyGrid[,] myGrid = new MyGrid[0, 0];
    float xOffset, yOffset; // TODO xOffset, yOffset ya da Vector2 offset; ++

    private void Awake()
    {
        myGrid = new MyGrid[sizeY, sizeX];
        xOffset = transform.position.x - ((sizeX / 2) * gridSize);
        yOffset = transform.position.y - ((sizeY / 2) * gridSize);
        GenerateGridMap();
    }

    // TODO bos fonksyonlar++

    public void GenerateGridMap()
    {
        for (int i = 0; i < sizeY; i++)
        {
            for (int k = 0; k < sizeX; k++)
            {
                myGrid[i, k] = new MyGrid(xOffset + (k*gridSize) + gridSize / 2, yOffset + (i*gridSize) + gridSize / 2);
            }
        }

    }

    public MyGrid GetCurrentGrid(Vector2 pos)
    {


        MyGrid newGrid = myGrid[(int)pos.y, (int)pos.x];

        return newGrid;
    }

    public MyGrid GetCurrentGridInfinitly(ref Vector2 pos)
    {
        if (pos.x >= sizeX)
        {
            pos.x -= sizeX; // TODO float ve mod operatoru ne donuyor inan bilmiyorum ++
        }
        else if (pos.x < 0)
        {
            pos.x += sizeX;
        }

        if (pos.y >= sizeY)
        {
            pos.y -= sizeY;
        }
        else if (pos.y < 0)
        {
            pos.y += sizeY;
        }

        MyGrid newGrid = myGrid[(int)pos.y, (int)pos.x];

        return newGrid;
    }

    public void PlaceTheObjToGrid(Vector2 pos, GameObject obj,string tag)
    {
        if (pos.x >= sizeX)
        {
            pos.x -= sizeX; // TODO float ve mod operatoru ne donuyor inan bilmiyorum ++
        }
        else if (pos.x < 0)
        {
            pos.x += sizeX;
        }

        if (pos.y >= sizeY)
        {
            pos.y -= sizeY;
        }
        else if (pos.y < 0)
        {
            pos.y += sizeY;
        }

        MyGrid newGrid = myGrid[(int)pos.y, (int)pos.x];

        newGrid.placedObj = obj;
        newGrid.placedObjTag = tag;
        obj.transform.position = newGrid.worldPosition;
    }

    public void RemoveTheObjectFromGrid(Vector2 pos)
    {
        if (pos.x >= sizeX)
        {
            pos.x -= sizeX; // TODO float ve mod operatoru ne donuyor inan bilmiyorum ++
        }
        else if (pos.x < 0)
        {
            pos.x += sizeX;
        }

        if (pos.y >= sizeY)
        {
            pos.y -= sizeY;
        }
        else if (pos.y < 0)
        {
            pos.y += sizeY;
        }

        MyGrid newGrid = myGrid[(int)pos.y, (int)pos.x];
        newGrid.placedObjTag = null;
        newGrid.placedObj = null;
    }

    public Vector2 WorldPositionToGrid(Vector2 worldPos)
    {
        
        Vector2 gridPos = new Vector2((int)((worldPos.x - (xOffset) - gridSize / 2)/gridSize), (int)((worldPos.y - (yOffset) - gridSize / 2))/gridSize);
        return gridPos;
    }


    private void OnDrawGizmos()
    {

        xOffset = transform.position.x - ((sizeX / 2) * gridSize);
        yOffset = transform.position.y - ((sizeY / 2) * gridSize);


        for (int i = 0; i <= sizeY; i++)
        {
            for (int k = 0; k <= sizeX; k++)
            {
                Debug.DrawLine(new Vector2(xOffset, yOffset + (i * gridSize)), new Vector2(xOffset + (sizeX * gridSize), yOffset + (i * gridSize)));
                Debug.DrawLine(new Vector2(xOffset + (k * gridSize), yOffset), new Vector2(xOffset + (k * gridSize), yOffset + (sizeY * gridSize)));

                //Debug.DrawLine(new Vector2(transform.position.x , transform.position.y + i), new Vector2(transform.position.x + cols, transform.position.y + i));
                //Debug.DrawLine(new Vector2(transform.position.x + k, transform.position.y), new Vector2(transform.position.x + k, transform.position.y + rows));
            }

        }

    }
}
