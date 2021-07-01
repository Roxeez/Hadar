using System;
using Script.Game.Entities;
using Script.Game.Maps.Decoration;
using Script.Game.Maps;
using Script.Game.Maps.Trap;
using Script.Utility;
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
            Check.NotNull(Map, "Can't found map in scene");
            Check.NotNull(Player, "Can't found player in scene");
        }


        public Map Map { get; private set; }
        public Player Player { get; private set; }

        public Checkpoint LastCheckpoint { get; set; }
    }
}