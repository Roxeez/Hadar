using System;
using UnityEngine;

namespace Maps.Objects
{
    /// <summary>
    /// Represent the spawn of a Map
    /// </summary>
    public class Spawn : MapObject
    {
        /// <summary>
        /// Spawn point of this checkpoint
        /// </summary>
        public Vector2 SpawnPoint { get; private set; }
        
        private void Awake()
        {
            SpawnPoint = new Vector2
            {
                x = Position.x + 1,
                y = Position.y - 1.3f
            };
        }
    }
}