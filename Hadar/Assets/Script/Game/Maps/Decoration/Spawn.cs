using Script.Enum;
using Script.Extension;
using UnityEngine;

namespace Script.Game.Maps.Decoration
{
    public class Spawn : MapObject
    {
        protected override void OnAwake()
        {
            SpawnPoint = new Vector2
            {
                x = Position.x + 1,
                y = Position.y - 1.3f
            };
        }
        
        public Vector2 SpawnPoint { get; private set; }

        protected override void OnCollision(Collider2D other, CollisionSide side)
        {
            if (!other.IsPlayer())
            {
                return;
            }

            if (side != CollisionSide.Top)
            {
                return;
            }
            
            Animator.SetTrigger("animate");
        }
    }
}