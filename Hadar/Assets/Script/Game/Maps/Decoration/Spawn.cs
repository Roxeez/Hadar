using System;
using Script.Game.Maps;
using UnityEngine;

namespace Script.Game.Maps.Decoration
{
    public class Spawn : MapObject
    {
        [SerializeField] private Vector2 offset;
        
        public Vector2 SpawnPoint { get; private set; }

        private void Start()
        {
            SpawnPoint = new Vector2
            {
                x = Position.x + offset.x,
                y = Position.y + offset.y
            };
        }
    }
}