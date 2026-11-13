using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell 
{
    // References to north, south, east and west walls of a cell
    private MazeCell northWall  = null;
    private MazeCell southWall  = null;
    private MazeCell eastWall   = null;
    private MazeCell westWall   = null;

    // Cell Column and Row position
    public int Col  { get; private set; }
    public int Row  { get; private set; }

    public void MarkAsVisited() => status = MazeCellStatus.VISITED; 

    public bool HasNotBeenVisited()   => (status == MazeCellStatus.UNVISITED); 

    // Predicate functions that returns true if a wall exists
    //=======================================================
    public bool HasNorthWall()  => northWall == null; 
    public bool HasSouthWall()  => southWall == null; 
    public bool HasEastWall()   => eastWall == null; 
    public bool HasWestWall()   => westWall == null; 

    // Defines this cell as the starting cell
    // ======================================
    public void MarkPathAsStarting() => path = MazeCellPath.START;
    public void MarkAsPath() => path = MazeCellPath.PATH;
    public void MarkPathAsEnding() => path = MazeCellPath.END;

    public MazeCellPath GetMazePath() => path;

    private MazeCellPath path = MazeCellPath.NONE;

    private MazeCellStatus status = MazeCellStatus.UNVISITED;

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
                northWall = neighbor;
                neighbor.southWall = this;
            } else {
                southWall = neighbor;
                neighbor.northWall = this;
            }
        }

        // Neighbor is either East or West
        if (row == 0)
        {
            if (col == 1) 
            {
                eastWall = neighbor;
                neighbor.westWall = this;
            } else {
                westWall = neighbor;
                neighbor.eastWall = this;
            }
        }
    }
}

/* 
MazeCellStatus - Lets the maze generation algorithm know the processing status
of the cell as the logic is creating the maze path.  Note: The SPACE 
enumeration is used to designate an area of the maze as predefined.
 */
public enum MazeCellStatus
{
    UNVISITED,
    VISITED,
    SPACE
}

public enum MazeCellPath
{
    START,
    END,
    PATH,
    NONE
}
