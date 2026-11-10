using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCntrl : MonoBehaviour
{
    private MazeGenerator mazeGenerator = null;

    private MazeObject maze = null;

    // Start is called before the first frame update
    void Start()
    {
       mazeGenerator = new MazeGenerator(10, 10);

       maze = mazeGenerator.GenerateMaze();

       Debug.Log(maze);

       //DrawMaze();
    }

    void Update()
    {
        
    }

    public void OnDrawGizmos()
    {
        if (maze == null) return;

        Vector3 size = new Vector3(0.2f, 0.2f, 0.2f);

        for (int col = 0; col < maze.width; col++)
        {
            for (int row = 0; row < maze.height; row++)
            {
                Vector3 center = new Vector3(col+1.0f, row+1.0f, 0.0f);

                Gizmos.DrawWireCube(center, size);

                if (!maze.maze[col, row].HasNorthWall())
                {
                    Gizmos.DrawLine(center, center + new Vector3(0.0f, 0.5f, 0.0f));
                }

                if (!maze.maze[col, row].HasSouthWall())
                {
                    Gizmos.DrawLine(center, center + new Vector3(0.0f, -0.5f, 0.0f));
                }

                if (!maze.maze[col, row].HasEastWall())
                {
                    Gizmos.DrawLine(center, center + new Vector3(0.5f, 0.0f, 0.0f));
                }

                if (!maze.maze[col, row].HasWestWall())
                {
                    Gizmos.DrawLine(center, center + new Vector3(-0.5f, 0.0f, 0.0f));
                }
            }
        }
    }
}
