using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private ObstacleDatas obstacleData; // instances od Obstacledata.asset
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float tileSpacing = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (obstacleData == null) // checking if obstacledata is not null
        {
            Debug.LogError("Obstacle Data is not assigned!");
            return;
        }
        obstacleData.InitializeGrid();
        GenerateObstacles();
    }

    private void GenerateObstacles() // Generate Obstacle where player cant go
    {
        for (int row = 0; row < obstacleData.gridWidth; row++)
        {
            for (int col = 0; col < obstacleData.gridHeight; col++)
            {
                if (obstacleData.HasObstacle(row, col))
                {
                    Vector3 position = new Vector3(row * tileSpacing, 0.5f, col * tileSpacing);
                    Instantiate(obstaclePrefab, position, Quaternion.identity, transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}