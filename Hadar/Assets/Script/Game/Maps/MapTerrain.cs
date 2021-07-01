using UnityEngine;

namespace Script.Game.Maps
{
    [RequireComponent(typeof(CompositeCollider2D))]
    public class MapTerrain : MonoBehaviour
    {
        private void Awake()
        {
            Collider = GetComponent<CompositeCollider2D>();
        }
        
        public Collider2D Collider { get; private set; }
    }
}