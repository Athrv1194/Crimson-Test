using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public Vector2Int GridPosition { get; private set; } // Created Var for Grid Postioning
    public bool IsWalkable { get; set; } = true;

    // Initialize the tile with a position on the grid
    public void Initialize(Vector2Int position)
    {
        GridPosition = position;
    }

}
