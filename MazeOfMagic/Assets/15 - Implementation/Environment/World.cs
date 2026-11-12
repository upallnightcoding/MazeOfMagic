using System.Collections.Generic;
using UnityEngine;

namespace MazeOfMagic
{
    public class World : Stage
    {
        private Dictionary<int, Platform> platformMap;

        public World()
        {
            platformMap = new Dictionary<int, Platform>();
        }
    }
}
