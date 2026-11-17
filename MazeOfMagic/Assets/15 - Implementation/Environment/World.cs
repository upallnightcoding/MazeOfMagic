using UnityEngine;

namespace MazeOfMagic
{
    public interface World
    {
        public void InitializeWorld(int width, int height);

        public void MakeTransition(MazeCellPathDir pathDir);
    }
}
