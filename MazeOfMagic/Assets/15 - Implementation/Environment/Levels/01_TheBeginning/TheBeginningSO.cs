using UnityEngine;

[CreateAssetMenu(fileName = "TheBeginningSO", menuName = "Scriptable Objects/TheBeginningSO")]
public class TheBeginningSO : ScriptableObject
{
    public GameObject floorTile;

    public int floorSize;

    public float tileSize;

    public GameObject archway;

    public GameObject[] directionRunes;
}
