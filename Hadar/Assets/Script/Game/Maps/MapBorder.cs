using Script.Extension;
using UnityEngine;

namespace Script.Game.Maps
{
    [RequireComponent(typeof(CompositeCollider2D))]
    public class MapBorder : MonoBehaviour
    {
        private void Awake()
        {
            Collider = GetComponent<CompositeCollider2D>();
            GameManager = FindObjectOfType<GameManager>();
        }
        
        public Collider2D Collider { get; private set; }
        public GameManager GameManager { get; private set; }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.IsPlayer())
            {
                return;
            }
            
            GameManager.Player.Kill();
        }
    }
}