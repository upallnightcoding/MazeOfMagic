using System;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfMagic
{
    public class TheForgottenCrypts_World
    {
        private TheForgottenCryptsSO script = null;

        private GameObject environment = null;

        private Dictionary<int, RootAndRotate> platformsMap = null;

        public TheForgottenCrypts_World(GameObject environment, TheForgottenCryptsSO script)
        {
            this.platformsMap = new Dictionary<int, RootAndRotate>();
            this.script = script;
            this.environment = environment;

            SetPlatformMap();
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        public GameObject Render(MazeCell mazeCell)
        {
            GameObject parent = new GameObject("TheForgottenCrypts");
            parent.transform.SetParent(environment.transform);

            int mazePathCode = mazeCell.CalculateMazePathCode();

            RootAndRotate rootAndRotate = platformsMap[mazePathCode];

            GameObject platform = UnityEngine.Object.Instantiate(script.platformsPrefabs[rootAndRotate.root], parent.transform);
            platform.transform.localRotation = Quaternion.Euler(0.0f, rootAndRotate.rotate * 90.0f, 0.0f);

            //script.platformsPrefabs[rootAndRotate.root].transform.rotation = Quaternion.Euler(0.0f, rootAndRotate.rotate * 90.0f, 0.0f);

            return parent;
        }

        public void SetPlatformMap()
        {
            platformsMap.Add( 1, new RootAndRotate(0, 3));
            platformsMap.Add( 2, new RootAndRotate(0, 1));
            platformsMap.Add( 3, new RootAndRotate(2, 1));
            platformsMap.Add( 4, new RootAndRotate(0, 2));
            platformsMap.Add( 5, new RootAndRotate(1, 2));
            platformsMap.Add( 6, new RootAndRotate(1, 1));
            platformsMap.Add( 7, new RootAndRotate(3, 1));
            platformsMap.Add( 8, new RootAndRotate(0, 0));
            platformsMap.Add( 9, new RootAndRotate(1, 3));
            platformsMap.Add(10, new RootAndRotate(1, 0));
            platformsMap.Add(11, new RootAndRotate(3, 3));
            platformsMap.Add(12, new RootAndRotate(2, 0));
            platformsMap.Add(13, new RootAndRotate(3, 2));
            platformsMap.Add(14, new RootAndRotate(3, 0));
            platformsMap.Add(15, new RootAndRotate(4, 0));
        }
    }

    public class RootAndRotate {
        public int root;
        public int rotate;

        public RootAndRotate(int root, int rotate)
        {
            this.root = root;
            this.rotate = rotate;
        }
    }
}