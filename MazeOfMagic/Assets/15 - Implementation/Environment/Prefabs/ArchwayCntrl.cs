using System.Collections;
using UnityEngine;

namespace MazeOfMagic
{
    public class ArchwayCntrl : MonoBehaviour
    {
        private GameObject mark = null;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetMarker(GameObject mark)
        {
            this.mark = mark;

            StartCoroutine(SpinContinuously(20.0f));
        }

        private IEnumerator SpinContinuously(float degreesPerSecond)
        {
            while (true)
            {
                mark.transform.Rotate(Vector3.up * degreesPerSecond * Time.deltaTime);
                yield return null;
            }
        }
    }
}
