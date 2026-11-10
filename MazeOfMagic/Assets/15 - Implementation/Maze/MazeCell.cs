using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell 
{
    // Type of Cell
    public MazeCellType Type    { get; private set; } = MazeCellType.UNVISITED;

    // References to north, south, east and west walls of a cell
    public MazeCell NorthWall   { get; private set; } = null;
    public MazeCell SouthWall   { get; private set; } = null;
    public MazeCell EastWall    { get; private set; } = null;
    public MazeCell WestWall    { get; private set; } = null;

    // Cell Column and Row position
    public int Col              { get; private set; }
    public int Row              { get; private set; }

    //public Vector3 Position     { get; set; }

    public void MarkAsVisited() => Type = MazeCellType.VISITED; 

    public bool HasNotBeenVisited()   => (Type == MazeCellType.UNVISITED); 

    // Predicate functions that returns true if a call exists
    public bool HasNorthWall()  => NorthWall == null; 
    public bool HasSouthWall()  => SouthWall == null; 
    public bool HasEastWall()   => EastWall == null; 
    public bool HasWestWall()   => WestWall == null; 

    public MazeCell(int col, int row) 
    {
        this.Col = col;
        this.Row = row;
    }

    public void CollapseWall(MazeCell neighbor)
    {
        int col = neighbor.Col - Col;
        int row = neighbor.Row - Row;

        //Neighbor is either North or South
        if (col == 0) 
        {
            if (row == 1) 
            {
                NorthWall = neighbor;
                neighbor.SouthWall = this;
            } else {
                SouthWall = neighbor;
                neighbor.NorthWall = this;
            }
        }

        // Neighbor is either East or West
        if (row == 0)
        {
            if (col == 1) 
            {
                EastWall = neighbor;
                neighbor.WestWall = this;
            } else {
                WestWall = neighbor;
                neighbor.EastWall = this;
            }
        }
    }
}

public enum MazeCellType
{
    UNVISITED,
    VISITED,
    SPACE
}
