using UnityEngine;

namespace Extension
{
    public static class Collider2DExtensions
    {
        public static bool IsPlayer(this Collider2D col)
        {
            return col.CompareTag("Player");
        }
    }
}