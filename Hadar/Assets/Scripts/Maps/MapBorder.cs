using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Utility;

namespace Maps
{
    /// <summary>
    /// Represent our map border
    /// </summary>
    public class MapBorder : MonoBehaviour
    {
        private GameManager gameManager;
        
        public CompositeCollider2D Collider { get; private set; }
        
        private void Awake()
        {
            Collider = GetComponent<CompositeCollider2D>();
            gameManager = SceneUtility.GetSceneObject<GameManager>();
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.CompareTag("Player"))
            {
                return;
            }
            
            gameManager.Respawn();
        }
    }
}