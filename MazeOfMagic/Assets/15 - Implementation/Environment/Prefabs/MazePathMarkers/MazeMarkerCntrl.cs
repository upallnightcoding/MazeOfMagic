using UnityEngine;
using MazeOfMagic;
using System.Collections;

public class MazeMarkerCntrl : MonoBehaviour
{
    private float markerRotationSpeed = 40.0f;

    private GameObject marker = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMazeMarker(GameObject rune)
    {
        marker = Object.Instantiate(rune, gameObject.transform);
        marker.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        marker.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        StartCoroutine(SpinContinuously());
    }

    private IEnumerator SpinContinuously()
    {
        while (true)
        {
            marker.transform.Rotate(Vector3.up * markerRotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter Archway ...");
    }

}
