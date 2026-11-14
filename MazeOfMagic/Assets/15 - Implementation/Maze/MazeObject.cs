using System.Collections.Generic;
using UnityEngine;

namespace MazeOfMagic
{
    public class MazeObject
    {
        public MazeCell[,] maze = null;

        public int width = 0;
        public int height = 0;

        public MazeCell startingCell = null;

        public MazeObject(MazeCell[,] maze, int width, int height, MazeCell startingCell)
        {
            this.maze = maze;
            this.width = width;
            this.height = height;
            this.startingCell = startingCell;
        }

        public MazeCell GetStartingCell()
        {
            return(startingCell);
        }


    }
}