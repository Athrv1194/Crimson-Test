using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public GridManager gridManager; // put gridholder in the GridManager Field(Inspector Tab)
    public Transform playerUnit;   // put PlayerUnit in the player unit Field(Inspector Tab)

    private List<Vector3> currentPath = new List<Vector3>(); // Holds the path (world positions) the unit will follow to reach its target.

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect mouse click
        {
            Vector3? targetPosition = GetTilePositionUnderMouse();
            if (targetPosition.HasValue)
            {
                Vector2Int start = GetGridPosition(playerUnit.position);
                Vector2Int target = GetGridPosition(targetPosition.Value);

                currentPath = FindPath(start, target);
                if (currentPath.Count > 0)
                {
                    StartCoroutine(MovePlayerAlongPath());
                }
            }
        }
    }

    // Perform a raycast to determine if clicked tile or not
    private Vector3? GetTilePositionUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GridTile gridTile = hit.collider.GetComponent<GridTile>();
            if (gridTile != null && gridTile.IsWalkable)
            {
                return hit.collider.transform.position;
            }
        }
        return null;
    }

    // Convert world position to grid position
    private Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        return new Vector2Int(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.z));
    }

    // A* Algorithm
    private List<Vector3> FindPath(Vector2Int start, Vector2Int target)
    {
        
        return new List<Vector3>(); // Return calculated path
    }

    // Coroutine to move the player unit
    private IEnumerator MovePlayerAlongPath()
    {
        foreach (Vector3 point in currentPath)
        {
            while (Vector3.Distance(playerUnit.position, point) > 0.1f)
            {
                playerUnit.position = Vector3.MoveTowards(playerUnit.position, point, Time.deltaTime * 5f);
                yield return null;
            }
        }
    }
}

