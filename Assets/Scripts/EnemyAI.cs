using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IAI
{
    public GridManager gridManager; // put gridholder in the GridManager Field(Inspector Tab)
    public Transform enemyUnit;     // put EnemyUnit in the enemy unit Field(Inspector Tab)
    public Transform playerUnit;    // put PlayerUnit in the player unit Field(Inspector Tab)

    public float enemySpeed = 3.0f; // enemy speed


    void Update()
    {
        Vector2Int playerPosition = GetGridPosition(playerUnit.position);
        MoveToPlayer(playerPosition);
    }

    // Inherited method from IAI interface
    public void MoveToPlayer(Vector2Int playerPosition)
    {
        Vector2Int enemyPosition = GetGridPosition(enemyUnit.position);
        
        // Checking if the enemy is already at the player's position
        if (enemyPosition == playerPosition)
            return;

        // Get possible moves
        List<Vector2Int> possibleMoves = GetNeighbors(enemyPosition);

        // Find the closest tile to the player
        Vector2Int bestMove = possibleMoves[0];
        float minDistance = Vector2Int.Distance(playerPosition, bestMove);

        foreach (var move in possibleMoves)
        {
            float distance = Vector2Int.Distance(playerPosition, move);
            if (distance < minDistance)
            {
                bestMove = move;
                minDistance = distance;
            }
        }

        
        MoveEnemy(bestMove);
    }
    // This function converts a 3D world position into a 2D grid coordinate.
    private Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        return new Vector2Int(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.z));
    }

    private void MoveEnemy(Vector2Int targetPosition)
    {
        Vector3 targetWorldPosition = new Vector3(targetPosition.x, enemyUnit.position.y, targetPosition.y);
        enemyUnit.position = Vector3.MoveTowards(enemyUnit.position, targetWorldPosition, Time.deltaTime * enemySpeed);
    }
    // Provides a list of neighboring tiles 
    private List<Vector2Int> GetNeighbors(Vector2Int currentPosition)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>
        {
            new Vector2Int(currentPosition.x + 1, currentPosition.y),
            new Vector2Int(currentPosition.x - 1, currentPosition.y),
            new Vector2Int(currentPosition.x, currentPosition.y + 1),
            new Vector2Int(currentPosition.x, currentPosition.y - 1)
        };

        // Filter out of bounds
        neighbors.RemoveAll(n => n.x < 0 || n.x >= gridManager.gridWidth || n.y < 0 || n.y >= gridManager.gridHeight);

        return neighbors;
    }
}
