using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfMagic
{
    public class MazeCntrl : MonoBehaviour
    {
        private MazeGenerator mazeGenerator = null;

        private MazeObject maze = null;

        // Start is called before the first frame update
        void Start()
        {
           
        }

        void Update()
        {

        }

        public void Generate()
        {
           

            //DrawMaze();
        }

        public MazeObject GetMaze()
        {
            return(maze);
        }
    }
}