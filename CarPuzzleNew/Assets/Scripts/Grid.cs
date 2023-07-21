using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Grid : MonoBehaviour
{
    private Cell[,] worldgrid;
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] float cellsize;
    public int VerticalIndex;
    public int HorizontalIndex;

    

    public string[] levelDataValue;

    public LevelDataSO levelDataSO;
    public int currentLevel = 1;

    public GameObject obstacle;
    private void Start()
    {
        levelDataSO.ReadDataFromCSV();
        CreateGrid();
     
    }

  

    private void CreateGrid()
    {
        worldgrid = new Cell[width, height];
       
        for (int i = 0;i < worldgrid.GetLength(0); i++)
        {
            for(int j = 0;j < worldgrid.GetLength(1); j++)
            {
               
                worldgrid[i, j] = new Cell(GetCellPosition(i, j), false);
                Debug.DrawLine(worldgrid[i, j].position, GetCellPosition(i, j + 1), Color.green, 300f);
                Debug.DrawLine(worldgrid[i, j].position, GetCellPosition(i + 1, j), Color.green, 300f);
            }
        }
        Debug.DrawLine(GetCellPosition(0, height), GetCellPosition(width, height), Color.green, 300f);
        Debug.DrawLine(GetCellPosition(width, 0), GetCellPosition(width, height), Color.green, 300f);
        worldgrid[0, 3].isblocked = true;
        worldgrid[2, 2].isblocked = true;
        worldgrid[1, 4].isblocked = true;
        SetBlockedAreas();
    }

    private void SetBlockedAreas()
    {
   
        for (int i = 0; i < levelDataSO.levelDataString.GetLength(0); i++)
        {
            for (int j = 0; j < levelDataSO.levelDataString.GetLength(1); j++)
            {
                if (worldgrid[i, j].isblocked == true)
                {
                  
                    Vector3 Position = GetCellCenter(GetCellPosition(i,j));
                    Instantiate(obstacle, Position, Quaternion.identity);
                }

            }
        }
    }

   
    public Vector3 GetCellPosition(int x, int y)
    {
        return new Vector3(x * cellsize, 0f, y * cellsize);
    }
    public Vector3 GetCellCenter(Vector3 cellposition)
    {
        return cellposition + new Vector3(cellsize, 0f, cellsize) * 0.5f;
    }

    public Vector3 GetUpEndPosition()
    {
        int index = 0;
        for(int y = VerticalIndex;y < height;y++)
        {
            if(worldgrid[HorizontalIndex,y].isblocked == true)
            {
                VerticalIndex = y - 1;
                return GetCellCenter(GetCellPosition(HorizontalIndex,VerticalIndex));
            }
            index = y;
        }
        VerticalIndex = index;
        return GetCellCenter(GetCellPosition(HorizontalIndex, index));
    }

    public Vector3 GetDownEndPosition()
    {
        int index = 0;
        for (int y = VerticalIndex; y >= 0; y--)
        {
            if (worldgrid[HorizontalIndex, y].isblocked == true)
            {
                VerticalIndex = y + 1;
                return GetCellCenter(GetCellPosition(HorizontalIndex, VerticalIndex));
            }
            index = y;
        }
        VerticalIndex = index;
        return GetCellCenter(GetCellPosition(HorizontalIndex, index));
    }

    public Vector3 GetRightEndPosition()
    {
        int index = 0;
        for (int x = HorizontalIndex; x < width; x++)
        {
            if (worldgrid[x, VerticalIndex].isblocked == true)
            {
                HorizontalIndex = x - 1;
                return GetCellCenter(GetCellPosition(HorizontalIndex, VerticalIndex));
            }
            index = x;
        }
        HorizontalIndex = index;
        return GetCellCenter(GetCellPosition(index, VerticalIndex));
    }

    public Vector3 GetLeftEndPosition()
    {
        int index = 0;
        for (int x = HorizontalIndex; x >= 0 ; x--)
        {
            if (worldgrid[x, VerticalIndex].isblocked == true)
            {
                HorizontalIndex = x + 1;
                return GetCellCenter(GetCellPosition(HorizontalIndex, VerticalIndex));
            }
            index = x;
        }
        HorizontalIndex = index;
        return GetCellCenter(GetCellPosition(index, VerticalIndex));
    }

}

public class Cell
{
    public Cell(Vector3 position,bool isblocked)
    {
        this.position = position;
        this.isblocked = isblocked;

    }
    public Vector3 position;
    public bool isblocked;
}
