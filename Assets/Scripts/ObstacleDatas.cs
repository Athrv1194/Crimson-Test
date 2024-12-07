using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Grid/Obstacle Data")]
public class ObstacleDatas : ScriptableObject
{
    public int gridWidth = 10;
    public int gridHeight = 10;
    [HideInInspector] public bool[,] Obstacles;

    public void InitializeGrid()
    {
        if (Obstacles == null || Obstacles.GetLength(0) != gridWidth || Obstacles.GetLength(1) != gridHeight)
        {
            Obstacles = new bool[gridWidth, gridHeight];
        }
    }

    public bool HasObstacle(int x, int y)
    {
        return Obstacles != null && Obstacles[x, y];
    }

    public void SetObstacle(int x, int y, bool isBlocked)
    {
        if (Obstacles != null) 
        {
           Obstacles[x, y] = isBlocked;
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
}