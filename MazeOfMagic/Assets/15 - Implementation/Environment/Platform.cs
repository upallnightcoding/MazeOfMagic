using UnityEngine;

namespace MazeOfMagic
{
    public interface Platform
    {
        public int GetPlatformType();

        public void Render();

        public void RotatePlatform();
    }
}
