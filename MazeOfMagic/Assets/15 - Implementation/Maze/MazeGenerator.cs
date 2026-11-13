using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MazeOfMagic
{
    public class MazeGenerator
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private bool IsMazeStackEmpty() => (mazeStack.Count == 0);

        private MazeCell[,] maze = null;
        private Stack<MazeCell> mazeStack;
        private Stack<MazeCell> pathStack;

        public MazeGenerator(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            mazeStack = new Stack<MazeCell>();
            pathStack = new Stack<MazeCell>();

            maze = new MazeCell[width, height];
        }

        public MazeObject GenerateMaze()
        {
            InitMazeGenerator();

            while (!IsMazeStackEmpty())
            {
                WalkMaze(PickAValidNeighbor(mazeStack.Peek()));
            }

            SetMazePath();

            return (new MazeObject(maze, Width, Height));
        }

        private void WalkMaze(MazeCell neighbor)
        {
            if (neighbor != null)
            {
                neighbor.MarkAsVisited();
                mazeStack.Push(neighbor);
                ComparePathStacks();
            }
            else
            {
                mazeStack.Pop();
            }
        }

        private void SetMazePath()
        {
            int size = pathStack.Count;
            int count = 0;

            foreach (MazeCell cell in pathStack)
            {
                if (count == 0)
                {
                    cell.MarkPathAsStarting();
                } else if (count == (size - 1))
                {
                    cell.MarkPathAsEnding();
                } else
                {
                    cell.MarkAsPath();
                }

                count++;
            }

        }

        private void ComparePathStacks()
        {
            if (mazeStack.Count > pathStack.Count)
            {
                MazeCell[] array = new MazeCell[mazeStack.Count];
                mazeStack.CopyTo(array, 0);
                Array.Reverse(array);
                pathStack = new Stack<MazeCell>(array);
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

            return (validNeighbor);
        }

        private bool IsOnBoard(int col, int row)
        {
            return (((col >= 0) && (col < Width)) && ((row >= 0) && (row < Height)));
        }

        private void InitMazeGenerator()
        {
            BuildMaze();

            SetStartingCell();
        }


        private void BuildMaze()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    maze[col, row] = new MazeCell(col, row);
                }
            }
        }

        /*
        SetStartingCell() - Selects the starting point cell of the maze,
        marks the cell as visited and places the cell on the maze
        stack.
         */
        private void SetStartingCell()
        {
            MazeCell cell = PickRandomCell();
            cell.MarkAsVisited();
            mazeStack.Push(cell);
        }

        private MazeCell PickRandomCell()
        {
            return (maze[GetRandom(Width), GetRandom(Height)]);
        }

        private int GetRandom(int n)
        {
            return (UnityEngine.Random.Range(0, n));
        }
    }
}