using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MazeGenerator 
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    private bool IsMazeStackEmpty() => (mazeStack.Count == 0);

    private MazeCell[,] maze = null;
    private Stack<MazeCell> mazeStack;

    public MazeGenerator(int width, int height)
    {
        this.Width = width;
        this.Height = height;

        mazeStack = new Stack<MazeCell>();
        maze = new MazeCell[width, height];
    }

    public MazeObject GenerateMaze()
    {
        InitMazeGenerator();

        while (!IsMazeStackEmpty()) 
        {
            WalkMaze(PickAValidNeighbor(mazeStack.Peek()));
        }

        return(new MazeObject(maze, Width, Height));
    }

    private void WalkMaze(MazeCell neighbor)
    {
        if (neighbor != null) 
        {
            neighbor.MarkAsVisited();
            mazeStack.Push(neighbor);
        } else {
            mazeStack.Pop();
        }
    }

    private MazeCell PickAValidNeighbor(MazeCell currentCell)
    {
        Tuple<int, int>[] neighbors = {
            Tuple.Create(0, 1),    // North
            Tuple.Create(0, -1),     // South
            Tuple.Create(1, 0),     // East
            Tuple.Create(-1, 0)     // West
        };

        List<MazeCell> validNeighborList = new List<MazeCell>();

        foreach (Tuple<int, int> neighbor in neighbors) 
        {
            int col = currentCell.Col + neighbor.Item1;
            int row = currentCell.Row + neighbor.Item2;

            if (IsOnBoard(col, row)) 
            {
                MazeCell candidate = maze[col, row];

                if (candidate.HasNotBeenVisited())
                {
                    validNeighborList.Add(candidate);
                }
            }
        }

        MazeCell validNeighbor = null;
        int nNeighbors = validNeighborList.Count;

        if (nNeighbors > 0) 
        {
            validNeighbor = validNeighborList[GetRandom(nNeighbors)];
            currentCell.CollapseWall(validNeighbor);
        }

        return(validNeighbor);
    }

    private bool IsOnBoard(int col, int row)
    {
        return(((col >= 0) && (col < Width)) && ((row >= 0) && (row < Height)));
    }

    private void InitMazeGenerator()
    {
        BuildMaze();

        SetStartingCell();
    }

    private void BuildMaze()
    {
        for (int col = 0; col < Width; col++) 
        {
            for (int row = 0; row < Height; row++)
            {
                maze[col, row] = new MazeCell(col, row);
            }
        }
    }

    private void SetStartingCell()
    {
        MazeCell cell = PickRandomCell();
        cell.MarkAsVisited();
        mazeStack.Push(cell);
    }

    private MazeCell PickRandomCell()
    {
        return(maze[GetRandom(Width), GetRandom(Height)]);
    }

    private int GetRandom(int n) 
    {
        return(UnityEngine.Random.Range(0, n));
    }
}
