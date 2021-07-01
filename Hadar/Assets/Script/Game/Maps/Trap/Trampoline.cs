using System;
using System.Collections;
using Script.Enum;
using Script.Extension;
using Script.Game.Maps;
using UnityEngine;

namespace Script.Game.Maps.Trap
{
    public class Trampoline : MapObject
    {
        protected override void OnCollision(Collider2D other, CollisionSide side)
        {
            if (!other.IsPlayer() || side != CollisionSide.Top)
            {
                return;
            }

            StartCoroutine(ScheduledBump());
        }

        private IEnumerator ScheduledBump()
        {
            Animator.SetTrigger("activated");
            
            yield return new WaitForSeconds(0.2f);
            
            GameManager.Player.Bump(25.0f);
        }
    }
}