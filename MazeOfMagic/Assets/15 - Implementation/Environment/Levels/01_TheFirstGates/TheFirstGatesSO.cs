using UnityEngine;

[CreateAssetMenu(fileName = "TheFirstGatesSO", menuName = "Scriptable Objects/TheFirstGatesSO")]
public class TheFirstGatesSO : ScriptableObject
{
    public GameObject floorTile;

    public int floorSize;

    public float tileSize;

    public GameObject archway;

    public GameObject mazePathMarker;

    public GameObject[] runes;
}
