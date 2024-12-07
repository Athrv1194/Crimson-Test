using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHoverEffect : MonoBehaviour
{
    private GridTile lastHoveredTile; // The last tile that was hovered over
    [SerializeField] private Color hoverColor = Color.yellow; // Hover effect color
    [SerializeField] private Color normalColor = Color.white; // Default tile color
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HighlightHoveredTile();
    }

    private void HighlightHoveredTile()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null) return;

        // Raycast from the mouse position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Check if the raycast hit a tile
            GridTile gridTile = hit.collider.GetComponent<GridTile>();
            if (gridTile != null)
            {
                // If the tile is new, apply the hover effect
                if (gridTile != lastHoveredTile)
                {
                    ResetLastHoveredTile(); // Reset the previous tile
                    ApplyHoverEffect(gridTile); // Apply hover effect to the current tile
                    lastHoveredTile = gridTile; // Update the last hovered tile
                }
            }
        }
        else
        {
            // If no tile is hit, reset the last hovered tile
            ResetLastHoveredTile();
        }
    }

    private void ApplyHoverEffect(GridTile tile)
    {
        Renderer renderer = tile.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = hoverColor; // Change the color to hover color
        }
    }

    private void ResetLastHoveredTile()
    {
        if (lastHoveredTile != null)
        {
            Renderer renderer = lastHoveredTile.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = normalColor; // Reset to default color
            }
            lastHoveredTile = null;
        }
    }
}
