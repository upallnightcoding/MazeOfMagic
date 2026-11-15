using Unity.Mathematics;
using UnityEngine;

namespace MazeOfMagic
{
    public class TheBeginning_World
    {
        private TheBeginningSO script;
        private GameObject environment;

        public TheBeginning_World(GameObject environment, TheBeginningSO script)
        {
            this.script = script;
            this.environment = environment;
        }

        public GameObject Render(MazeCell cell)
        {
            GameObject parent = new GameObject("TheBeginning");
            parent.transform.SetParent(environment.transform);

            DrawPlatform(parent, script);

            if (!cell.HasNorthWall()) DrawArchway(parent, script, MazeCellPathDir.NORTH);
            if (!cell.HasSouthWall()) DrawArchway(parent, script, MazeCellPathDir.SOUTH);
            if (!cell.HasEastWall()) DrawArchway(parent, script, MazeCellPathDir.EAST);
            if (!cell.HasWestWall()) DrawArchway(parent, script, MazeCellPathDir.WEST);

            return(parent);
        }

        protected void DrawArchway(GameObject parent, TheBeginningSO script, MazeCellPathDir pathDir)
        {
            float x = 0.0f, z = 0.0f;
            float rotate = 0.0f;

            switch (pathDir)
            {
                case MazeCellPathDir.NORTH:
                    x = 0.0f;
                    z = System.MathF.Floor(script.floorSize / 2.0f) * script.tileSize + (script.tileSize / 2.5f);
                    rotate = 180.0f;
                    break;
                case MazeCellPathDir.SOUTH:
                    x = 0.0f;
                    z = -(System.MathF.Floor(script.floorSize / 2.0f) * script.tileSize + (script.tileSize / 2.5f));
                    rotate = 0.0f;
                    break;
                case MazeCellPathDir.EAST:
                    x = System.MathF.Floor(script.floorSize / 2.0f) * script.tileSize + (script.tileSize / 2.5f);
                    z = 0.0f;
                    rotate = -90.0f;
                    break;
                case MazeCellPathDir.WEST:
                    x = -(System.MathF.Floor(script.floorSize / 2.0f) * script.tileSize + (script.tileSize / 2.5f));
                    z = 0.0f;
                    rotate = 90.0f;
                    break;
            }

            RenderArchway(parent, script, x, z, rotate, pathDir);
        }

        private void RenderArchway(
        GameObject parent,
        TheBeginningSO script,
        float x, float z,
        float rotate,
        MazeCellPathDir pathDir
        )
        {
            Vector3 position = new Vector3(x, 0.0f, z);
            GameObject archway = Object.Instantiate(script.archway, parent.transform);
            archway.transform.localPosition = position;
            archway.transform.localRotation = Quaternion.Euler(0.0f, rotate, 0.0f);
            archway.GetComponent<ArchwayCntrl>().SetMarker(script.mazePathMarker, pathDir, GetPathDirRune(script, pathDir));
        }

        private GameObject GetPathDirRune(TheBeginningSO script, MazeCellPathDir pathDir)
        {
            GameObject rune = null;

            switch (pathDir)
            {
                case MazeCellPathDir.NORTH:
                    rune = script.runes[0];
                    break;
                case MazeCellPathDir.SOUTH:
                    rune = script.runes[1];
                    break;
                case MazeCellPathDir.EAST:
                    rune = script.runes[2];
                    break;
                case MazeCellPathDir.WEST:
                    rune = script.runes[3];
                    break;
            }

            return (rune);
        }

        protected void DrawPlatform(GameObject parent, TheBeginningSO script)
        {
            float xPos = -System.MathF.Floor(script.floorSize / 2.0f) * script.tileSize;
            float zPos = -System.MathF.Floor(script.floorSize / 2.0f) * script.tileSize;

            float x = xPos;

            for (int width = 0; width < script.floorSize; width++)
            {
                float z = zPos;

                for (int height = 0; height < script.floorSize; height++)
                {
                    GameObject newTile = Object.Instantiate(script.floorTile, parent.transform);

                    newTile.transform.localPosition = new Vector3(x, 0.0f, z);

                    z += script.tileSize;
                }

                x += script.tileSize;
            }
        }
    }
}
