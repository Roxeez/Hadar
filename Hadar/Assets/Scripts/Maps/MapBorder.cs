using System;
using UnityEngine;
using Utility;

namespace Maps
{
    /// <summary>
    /// Represent our map border
    /// </summary>
    public class MapBorder : MonoBehaviour
    {
        private GameManager gameManager;

        private void Awake()
        {
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