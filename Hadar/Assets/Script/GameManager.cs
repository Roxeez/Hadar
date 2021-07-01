using Script.Game.Entities;
using Script.Game.Maps.Decoration;
using Script.Game.Maps;
using UnityEngine;

namespace Script
{
    public sealed class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            Map = FindObjectOfType<Map>();
            Player = FindObjectOfType<Player>();
        }

        private void Start()
        {
            Player.Position = Map.Spawn.SpawnPoint;
        }
        
        public Map Map { get; private set; }
        public Player Player { get; private set; }

        public Checkpoint LastCheckpoint { get; set; }
    }
}