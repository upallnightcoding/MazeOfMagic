using System.IO;
using UnityEngine;

namespace MazeOfMagic
{
    public class EnvironmentCntrl : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private EnvironmentSO script;

        //private TheBeginning world;
        //private TheForgottenCrypts world;

        private World world;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //world = GetComponent<TheForgottenCrypts>();
            world = GetComponent<TheFirstGates>();
            
            world.InitializeWorld(10, 10);
        }

        public void InitializeWorld()
        {
            world.InitializeWorld(10, 10);
        }

        private void MakeTransition(MazeCellPathDir pathDir)
        {
            world.MakeTransition(pathDir);
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
