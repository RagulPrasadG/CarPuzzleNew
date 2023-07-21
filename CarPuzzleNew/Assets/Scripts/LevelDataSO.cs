using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataSO",menuName = "Data/NewData")]
public class LevelDataSO : ScriptableObject
{
    public LevelData[] levelData;
    public TextAsset[] levelDataCSV;
    public string[,] levelDataString;

    public void ReadDataFromCSV()
    {
        levelData = new LevelData[levelDataCSV.Length];
        for(int i = 0;i<levelDataCSV.Length;i++)
        {
            string[] datalines = levelDataCSV[i].ToString().Split("\n");
        
            levelData[i] = new LevelData();
            levelDataString = new string[datalines.Length,datalines[i].Split(",").Length];

            for (int row = 0; row < levelDataString.GetLength(0); row++)
            {
                string[] values = datalines[row].Split(',');

                for (int col = 0; col < levelDataString.GetLength(1); col++)
                {
                    levelDataString[row, col] = values[col];  
                }
            }

        }
      

    }
}
[System.Serializable]
public struct LevelData
{
    public int width;
    public int height;
    public Cell[,] worldgrid;
    public Vector2Int carPositionIndex;
    public Vector2Int garagePositionIndex;

}