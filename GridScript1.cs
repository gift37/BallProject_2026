using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GridScript1 : MonoBehaviour
{
    [Header("Grid Dimensions")]
    public int width = 10;
    public int height = 5;
    public float cellSize = 1f;

    private Node[,] gridArray;

    void Start()
    {
        // Initialize the 2D data matrix
        gridArray = new Node[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridArray[x, y] = new Node(x, y);
            }
        }
    }

    // Helper function to turn world space into array indices
    public Node GetNodeFromWorldPos(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / cellSize);
        int y = Mathf.FloorToInt(worldPosition.z / cellSize); // Using Z for 3D ground floor

        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return gridArray[x, y];
        }
        return null;
    }

    // Draw the grid lines in the Unity Editor for debugging
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int x = 0; x <= width; x++)
        {
            Gizmos.DrawLine(new Vector3(x * cellSize, 0, 0), new Vector3(x * cellSize, 0, height * cellSize));
        }
        for (int y = 0; y <= height; y++)
        {
            Gizmos.DrawLine(new Vector3(0, 0, y * cellSize), new Vector3(width 