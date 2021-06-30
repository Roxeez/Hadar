using UnityEngine;

namespace Maps
{
    /// <summary>
    /// Represent walkable terrain of a map
    /// </summary>
    public class MapTerrain : MonoBehaviour
    {
        public CompositeCollider2D Collider { get; private set; }

        private void Awake()
        {
            Collider = GetComponent<CompositeCollider2D>();
        }
    }
}