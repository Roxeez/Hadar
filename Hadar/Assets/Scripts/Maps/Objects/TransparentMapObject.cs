using System;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;

namespace Maps.Objects
{
    /// <summary>
    /// Represent a map object who can be walked through (checkpoints)
    /// </summary>
    public abstract class TransparentMapObject : MapObject
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnCollision(other);
        }

        protected override void OnCollision(Collider2D other)
        {
            
        }
    }
}