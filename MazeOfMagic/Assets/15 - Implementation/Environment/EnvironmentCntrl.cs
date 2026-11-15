using System.IO;
using UnityEngine;

namespace MazeOfMagic
{
    public class EnvironmentCntrl : MonoBehaviour
    {
        [SerializeField] private GameObject player;

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

        private void MakeTransition(MazeCellPathDir pathDir)
        {
            Debug.Log("Making maze transition ... " + pathDir );

            //player.GetComponent<PlayerCntrl>().SetPosition(new Vector3(0.0f, 0.0f, 0.0f));

            world.MoveToNextMazeCell(pathDir);
        }

        private void OnEnable()
        {
            EventManager.Instance.OnMarkMazePath += MakeTransition;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnMarkMazePath -= MakeTransition;
        }
    }


}
