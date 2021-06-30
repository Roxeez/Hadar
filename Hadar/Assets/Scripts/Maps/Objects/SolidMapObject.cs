using UnityEngine;

namespace Maps.Objects
{
    public enum CollisionSide
    {
        Undefined,
        Top, 
        Bottom, 
        Left, 
        Right
    }
    
    /// <summary>
    /// Represent a solid map object (platform, start, finish)
    /// </summary>
    public abstract class SolidMapObject : MapObject
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            var side = CollisionSide.Undefined;

            if (other.contacts.Length > 0)
            {
                var contact = other.contacts[0].normal;

                if (Mathf.Abs(contact.y) > Mathf.Abs(contact.x))
                {
                    side = contact.y < 0 ? CollisionSide.Top : CollisionSide.Bottom;
                }
                else
                {
                    side = contact.x < 0 ? CollisionSide.Left : CollisionSide.Right;
                }
            }

            OnCollision(other.collider);
            OnCollision(other.collider, side);
        }

        protected override void OnCollision(Collider2D other)
        {
            
        }

        /// <summary>
        /// Method called when something collide with this object
        /// </summary>
        /// <param name="other">Collider colliding with this entity</param>
        /// <param name="side">Side where these entity collided</param>
        protected virtual void OnCollision(Collider2D other, CollisionSide side)
        {
            
        }
    }
}