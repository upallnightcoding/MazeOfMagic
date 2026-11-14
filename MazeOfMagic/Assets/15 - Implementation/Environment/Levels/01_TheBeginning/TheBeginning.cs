using System;
using Unity.VisualScripting;
using UnityEngine;

namespace MazeOfMagic
{
    public class TheBeginning : MonoBehaviour
    {
        [SerializeField] private TheBeginningSO script;

        private TheBeginning_World world = null;

        private MazeGenerator mazeGenerator = null;
        private MazeObject maze = null;

        void Start()
        {
            mazeGenerator = new MazeGenerator(10, 10);
            maze = mazeGenerator.GenerateMaze();            
            MazeCell startingCell = maze.GetStartingCell();

            world = new TheBeginning_World(gameObject, script);
            world.Render(startingCell);
        }

        public virtual int GetPlatformType()
        {
            return(-1);
        }

        public void Render()
        {
            
        }

        public virtual void RotatePlatform()
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
