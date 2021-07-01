using System;
using System.Collections;
using Script.Enum;
using Script.Extension;
using Script.Game.Maps;
using UnityEngine;

namespace Script.Game.Maps.Trap
{
    public class FallingPlatform : MapObject
    {
        [SerializeField] private float fallSpeed = 20.0f;
        
        private Vector2 startPosition;

        private void Start()
        {
            startPosition = Position;
            
            Physics2D.IgnoreCollision(Collider, GameManager.Map.Terrain.Collider);
            Physics2D.IgnoreCollision(Collider, GameManager.Map.Border.Collider);
        }

        protected override void OnCollision(Collider2D other, CollisionSide side)
        {
            if (!other.IsPlayer() || side != CollisionSide.Top)
            {
                return;
            }

            StartCoroutine(ScheduledFalling());
        }

        private IEnumerator ScheduledFalling()
        {
            Animator.SetTrigger("activated");
            
            yield return new WaitForSeconds(1);
            
            Rigidbody.isKinematic = false;
            Rigidbody.velocity = new Vector2(0, -fallSpeed);
        }

        protected override void Reset()
        {
            Rigidbody.velocity = Vector2.zero;
            Rigidbody.isKinematic = true;

            Position = startPosition;
        }
    }
}