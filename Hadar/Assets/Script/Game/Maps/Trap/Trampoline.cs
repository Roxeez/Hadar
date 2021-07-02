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
        [SerializeField] private float power;
        
        protected override void OnCollision(Collider2D other, CollisionSide side)
        {
            if (!other.IsPlayer() || side != CollisionSide.Top)
            {
                return;
            }
            
            Animator.SetTrigger("bump");
            GameManager.Player.Bump(new Vector2
            {
                y = power
            });
        }
    }
}