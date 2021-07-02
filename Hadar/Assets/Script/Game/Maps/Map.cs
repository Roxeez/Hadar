using Script.Game.Maps.Decoration;
using Script.Game.Maps.Trap;
using UnityEngine;

namespace Script.Game.Maps
{
    public sealed class Map : MonoBehaviour
    {
        public MapTerrain Terrain { get; private set; }
        public MapBorder Border { get; private set; }
        public Spawn Spawn { get; private set; }
        public Checkpoint[] Checkpoints { get; private set; }
        public Finale Finale { get; private set; }
        
        public Trampoline[] Trampolines { get; private set; }
        public FallingPlatform[] FallingPlatforms { get; private set; }

        private void Awake()
        {
            Terrain = FindObjectOfType<MapTerrain>();
            Border = FindObjectOfType<MapBorder>();
            Spawn = FindObjectOfType<Spawn>();
            Checkpoints = FindObjectsOfType<Checkpoint>();
            Finale = FindObjectOfType<Finale>();
            Trampolines = FindObjectsOfType<Trampoline>();
            FallingPlatforms = FindObjectsOfType<FallingPlatform>();
        }

        public void ResetTraps()
        {
            foreach (var platform in FallingPlatforms)
            {
                platform.Reset();
            }
        }
    }
}