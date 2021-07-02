using Script.Enum;
using Script.Extension;
using UnityEngine;

namespace Script.Game.Maps.Decoration
{
    public class Finale : MapObject
    {
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