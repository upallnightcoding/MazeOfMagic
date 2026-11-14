using System.Collections;
using UnityEngine;

namespace MazeOfMagic
{
    public class ArchwayCntrl : MonoBehaviour
    {

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetMarker(GameObject markerPrefab, GameObject rune)
        {
            GameObject marker = Object.Instantiate(markerPrefab, gameObject.transform);
            marker.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            marker.GetComponent<MazeMarkerCntrl>().SetMazeMarker(rune);
        }
    }
}
