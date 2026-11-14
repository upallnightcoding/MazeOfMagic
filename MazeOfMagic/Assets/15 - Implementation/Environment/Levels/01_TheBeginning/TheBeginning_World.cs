using Unity.Mathematics;
using UnityEngine;

namespace MazeOfMagic
{
    public class TheBeginning_World : TheBeginningBase
    {
        private TheBeginningSO script;
        private GameObject parent;

        public TheBeginning_World(GameObject parent, TheBeginningSO script)
        {
            this.script = script;
            this.parent = parent;
        }

        public void Render(MazeCell cell)  
        {
            DrawPlatform(parent, script);

            if (!cell.HasNorthWall()) DrawArchway(parent, script, MazeCellPathDir.NORTH);
            if (!cell.HasSouthWall()) DrawArchway(parent, script, MazeCellPathDir.SOUTH);
            if (!cell.HasEastWall()) DrawArchway(parent, script, MazeCellPathDir.EAST);
            if (!cell.HasWestWall()) DrawArchway(parent, script, MazeCellPathDir.WEST);
        }
    }
}
