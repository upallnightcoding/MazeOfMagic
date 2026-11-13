using MazeOfMagic;
using UnityEngine;

public class TheBeginningBase
{
    protected void DrawArchway(GameObject parent, TheBeginningSO script, int whichArchway)
    {
        float x = 0.0f, z = 0.0f;
        float rotate = 0.0f;

        switch(whichArchway)
        {
            case 8: 
                x = 0.0f;
                z = System.MathF.Floor(script.floorSize / 2.0f) * script.tileSize + (script.tileSize / 2.5f);
                rotate = 180.0f;
                break;
            case 4: 
                x = 0.0f;
                z = -(System.MathF.Floor(script.floorSize / 2.0f) * script.tileSize + (script.tileSize / 2.5f));
                rotate = 0.0f;
                break; 
            case 2: 
                x = System.MathF.Floor(script.floorSize / 2.0f) * script.tileSize + (script.tileSize / 2.5f);
                z = 0.0f;
                rotate = -90.0f;
                break; 
            case 1: 
                x = -(System.MathF.Floor(script.floorSize / 2.0f) * script.tileSize + (script.tileSize / 2.5f));
                z = 0.0f;
                rotate = 90.0f;
                break;
        }

        RenderArchway(parent, script, x, z, rotate);
    }

    private void RenderArchway(GameObject parent, TheBeginningSO script, float x, float z, float rotate) 
    {
        Vector3 position = new Vector3(x, 0.0f, z);
        GameObject archway = Object.Instantiate(script.archway, parent.transform);
        archway.transform.localPosition = position;
        archway.transform.localRotation = Quaternion.Euler(0.0f, rotate, 0.0f);

        GameObject mark = Object.Instantiate(script.directionRunes[0], parent.transform);
        mark.transform.localPosition = new Vector3(position.x, position.y + 0.5f, position.z);
        mark.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        
        archway.GetComponent<ArchwayCntrl>().SetMarker(mark);
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
    
        //float centerX = -(script.floorSize * script.tileSize) / 2.0f;
        //float centerY = -(script.floorSize * script.tileSize) / 2.0f;
        //parent.transform.position = new Vector3(centerX, 0.0f, centerY);
    }

}
