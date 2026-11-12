using UnityEngine;

namespace MazeOfMagic
{
    public class EnvironmentCntrl : MonoBehaviour
    {
        private TheBeginning world;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            world = GetComponent<TheBeginning>();

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
