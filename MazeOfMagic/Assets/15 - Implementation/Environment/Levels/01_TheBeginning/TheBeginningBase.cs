using MazeOfMagic;
using UnityEngine;

public class TheBeginningBase
{
    protected void DrawArchway(GameObject parent, TheBeginningSO script, MazeCellPathDir whichArchway)
    {
        float x = 0.0f, z = 0.0f;
        float rotate = 0.0f;

        switch(whichArchway)
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

        RenderArchway(parent, script, x, z, rotate, whichArchway);
    }

    private void RenderArchway(
        GameObject parent, 
        TheBeginningSO script, 
        float x, float z, 
        float rotate, 
        MazeCellPathDir whichArchway
    ) 
    {
        Vector3 position = new Vector3(x, 0.0f, z);
        GameObject archway = Object.Instantiate(script.archway, parent.transform);
        archway.transform.localPosition = position;
        archway.transform.localRotation = Quaternion.Euler(0.0f, rotate, 0.0f);
        archway.GetComponent<ArchwayCntrl>().SetMarker(script.mazePathMarker, script.runes[0]);
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
