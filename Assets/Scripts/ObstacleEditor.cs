using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObstacleEditor : EditorWindow
{
    private ObstacleDatas obstacleData;

    [MenuItem("Tools/Obstacle Editor")]
    public static void ShowWindow()
    {
        GetWindow<ObstacleEditor>("Obstacle Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Obstacle Editor", EditorStyles.boldLabel);
        obstacleData = (ObstacleDatas)EditorGUILayout.ObjectField("Obstacle Data", obstacleData, typeof(ObstacleDatas), false);
        if (obstacleData == null)
        {
            GUILayout.Label("No Obstacle Data assigned!", EditorStyles.helpBox);
            return;   
        }
        obstacleData.InitializeGrid();

        for (int row = 0; row < obstacleData.gridHeight; row++)
        {
            GUILayout.BeginHorizontal();
            for (int col = 0; col < obstacleData.gridWidth; col++)
            {
                bool isBlocked = obstacleData.HasObstacle(col, row);
                bool newBlocked = GUILayout.Toggle(isBlocked, "");
                if (newBlocked != isBlocked)
                {
                    obstacleData.SetObstacle(col, row, newBlocked);
                    EditorUtility.SetDirty(obstacleData);
                }
            }
            GUILayout.EndHorizontal();
        }

        if(GUILayout.Button("Save"))
        {
            AssetDatabase.SaveAssets();
            Debug.Log("Obstacle Data Saved!");
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