using UnityEngine;
using System.Collections;
using System.IO;

namespace MazeOfMagic
{

    public class MazeMarkerCntrl : MonoBehaviour
    {
        private float markerRotationSpeed = 40.0f;

        private GameObject marker = null;
        private MazeCellPathDir pathDir = MazeCellPathDir.NONE;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        public void SetMazeMarker(MazeCellPathDir pathDir, GameObject rune)
        {
            marker = Object.Instantiate(rune, gameObject.transform);
            marker.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            marker.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            this.pathDir = pathDir;

            StartCoroutine(SpinContinuously());
        }

        private IEnumerator SpinContinuously()
        {
            while (true)
            {
                marker.transform.Rotate(markerRotationSpeed * Time.deltaTime * Vector3.up);
                yield return null;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Player: " + other.gameObject.CompareTag("Player"));

            other.gameObject.GetComponent<PlayerCntrl>().SetPosition(new Vector3(0.0f, 0.0f, 0.0f));

            EventManager.Instance.InvokeOnMarkMazePath(pathDir);
        }

    }
}