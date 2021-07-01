using UnityEngine;

namespace Script.Extension
{
    public static class ColliderExtensions
    {
        public static bool IsPlayer(this Collider2D collider)
        {
            return collider.CompareTag("Player");
        }
    }
}