using System;
using Script.Game.Maps.Decoration;
using Script.Game.Maps.Trap;
using Script.Utility;
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

        private void Start()
        {
            Check.NotNull(Terrain, "Can't found MapTerrain object in scene");
            Check.NotNull(Border, "Can't found MapBorder object in scene");
            Check.NotNull(Spawn, "Can't found Spawn object in scene");
            Check.NotNull(Finale, "Can't found Finale object in scene");
        }
    }
}