using System;
using Unity.VisualScripting;
using UnityEngine;

namespace MazeOfMagic
{
    public class TheBeginning : MonoBehaviour
    {
        [SerializeField] private TheBeginningSO script;

        private TheBeginning_North north = null;

        void Start()
        {
            north = new TheBeginning_North(gameObject, script);

            north.Render();
        }

        public virtual int GetPlatformType()
        {
            return(-1);
        }

        public void Render()
        {
            
        }

        public virtual void RotatePlatform()
        {
            
        }
    }
}
