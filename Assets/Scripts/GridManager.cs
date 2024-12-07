using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject gridTilePrefab;
    [SerializeField] private int gridWidth = 10; // Grid width
    [SerializeField] private int gridHeight = 10; // Grid height
    [SerializeField] private float tileSpacing = 1.0f; // tilespacing
    [SerializeField] private Text tileInfoNum; // tile positioning UI Text
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main; // called out main camera
        GeneratedGrid();
    }

    // Function for Generating Grid
    private void GeneratedGrid()
    {

        for (int row = 0; row < gridWidth; row++)
        {
            for (int column = 0; column < gridHeight; column++)
            {
                GameObject tile = Instantiate(gridTilePrefab, transform);
                tile.transform.position = new Vector3(row * tileSpacing, 0, column * tileSpacing);
                GridTile gridTile = tile.GetComponent<GridTile>();
                if (gridTile != null)
                {
                    gridTile.Initialize(new Vector2Int(row, column));
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectHoveredTile();
    }

    //Detecting which tile hovered
    private void DetectHoveredTile()
    {
        if (mainCamera == null) return;

        // Perform a raycast from the mouse position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Checking if the object hit by the raycast 
            GridTile gridTile = hit.collider.GetComponent<GridTile>();
            if (gridTile != null)
            {
                // Displaying  tile's grid position(UI)
                tileInfoNum.text = $"Tile Position: {gridTile.GridPosition.x}, {gridTile.GridPosition.y}";
            }
        }
        else
        {
            // Clearing the UI text if no tile is hovered over
            tileInfoNum.text = "";
        }
    }
}
