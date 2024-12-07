using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving = false; // Tracks if the player is currently moving
    [SerializeField] private float moveSpeed = 5f; // Movement speed
    private void Update()
    {
        // Check for mouse click and ensure player isn't already moving
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            HandleMovement();
        }
    }
    private void HandleMovement()
    {
        // Perform a raycast from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GridTile gridTile = hit.collider.GetComponent<GridTile>();
            if (gridTile != null) // Ensure the clicked object is a grid tile
            {
                Vector3 targetPosition = new Vector3(
                    gridTile.transform.position.x, 
                    transform.position.y, 
                    gridTile.transform.position.z
                );
                // Start moving to the clicked position
                StartCoroutine(MoveToPosition(targetPosition));
            }
        }
    }
    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        isMoving = true;
        
        // Move towards the target position
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        
        // Ensure final position alignment and unlock movement
        transform.position = targetPosition;
        isMoving = false;
    }
}