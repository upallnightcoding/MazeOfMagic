using UnityEngine;

public class MazeObject
{
    public MazeCell[,] maze = null;

    public int width = 0;
    public int height = 0;

    public MazeObject(MazeCell[,] maze, int width, int height)
    {
        this.maze = maze;
        this.width = width;
        this.height = height;
    }

    
}
