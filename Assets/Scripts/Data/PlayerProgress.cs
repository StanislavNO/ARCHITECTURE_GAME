using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class PlayerProgress 
    {
        public WorldData WorldData;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
        }
    }
}