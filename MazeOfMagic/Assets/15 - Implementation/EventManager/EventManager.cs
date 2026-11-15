using System;
using UnityEngine;

namespace MazeOfMagic
{
    public class EventManager
    {
        public event Action<MazeCellPathDir> OnMarkMazePath = delegate { };

        public void InvokeOnMarkMazePath(MazeCellPathDir marker) => OnMarkMazePath.Invoke(marker);

        public static EventManager Instance
        {
            get
            {
                aInstance ??= new EventManager();

                return (aInstance);
            }
        }

        public static EventManager aInstance = null;
    }
}