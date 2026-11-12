using Unity.Mathematics;
using UnityEngine;

namespace MazeOfMagic
{
    public class TheBeginning_North : TheBeginningBase
    {
        private TheBeginningSO script;
        private GameObject parent;

        public TheBeginning_North(GameObject parent, TheBeginningSO script)
        {
            this.script = script;
            this.parent = parent;
        }

        public void Render()
        {
            DrawPlatform(parent, script);
            DrawArchway(parent, script, 8);
            DrawArchway(parent, script, 4);
            DrawArchway(parent, script, 2);
            DrawArchway(parent, script, 1);
        }
    }
}
