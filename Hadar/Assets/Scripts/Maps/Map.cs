using Maps.Objects;
using UnityEngine;
using Utility;

namespace Maps
{
    /// <summary>
    /// Represent a game map
    /// </summary>
    public class Map : MonoBehaviour
    {
        /// <summary>
        /// Spawn of this map
        /// </summary>
        public Spawn Spawn { get; private set; }
        
        /// <summary>
        /// Finish line of this map
        /// </summary>
        public Finish Finish { get; private set; }
        
        /// <summary>
        /// Border of this map
        /// </summary>
        public MapBorder Border { get; private set; }
        
        /// <summary>
        /// Checkpoints of this map (can be empty)
        /// </summary>
        public Checkpoint[] Checkpoints { get; private set; }

        private void Awake()
        {
            Spawn = SceneUtility.GetSceneObject<Spawn>();
            Finish = SceneUtility.GetSceneObject<Finish>();
            Border = SceneUtility.GetSceneObject<MapBorder>();
            Checkpoints = SceneUtility.GetSceneObjects<Checkpoint>();
        }
    }
}