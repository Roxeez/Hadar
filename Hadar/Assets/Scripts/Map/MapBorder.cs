using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Map
{
    public class MapBorder : MonoBehaviour
    {
        public event Action CollidedWithPlayer;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            CollidedWithPlayer?.Invoke();
        }

    }
}
