using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfMagic
{
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
                    MazeCell cell = maze.maze[col, row];

                    switch(cell.GetMazePath())
                    {
                        case MazeCellPath.START:
                        Gizmos.color = Color.green;
                        break;
                        case MazeCellPath.PATH:
                        Gizmos.color = Color.yellow;
                        break;
                        case MazeCellPath.END:
                        Gizmos.color = Color.red;
                        break;
                        default:
                        break;    
                    }

                    Vector3 center = new Vector3(col + 1.0f, row + 1.0f, 0.0f);
                    Gizmos.DrawWireCube(center, size);

                    Gizmos.color = Color.white;

                    if (!cell.HasNorthWall())
                    {
                        Gizmos.DrawLine(center, center + new Vector3(0.0f, 0.5f, 0.0f));
                    }

                    if (!cell.HasSouthWall())
                    {
                        Gizmos.DrawLine(center, center + new Vector3(0.0f, -0.5f, 0.0f));
                    }

                    if (!cell.HasEastWall())
                    {
                        Gizmos.DrawLine(center, center + new Vector3(0.5f, 0.0f, 0.0f));
                    }

                    if (!cell.HasWestWall())
                    {
                        Gizmos.DrawLine(center, center + new Vector3(-0.5f, 0.0f, 0.0f));
                    }
                }
            }
        }
    }
}