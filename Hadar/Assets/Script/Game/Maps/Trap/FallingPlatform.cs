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
        [SerializeField] private float delay = 1.0f;
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
            if (other.IsPlayer() && side == CollisionSide.Top)
            {
                StartCoroutine(ScheduledFalling());
            }
        }

        private IEnumerator ScheduledFalling()
        {
            Animator.SetTrigger("fall");
            
            yield return new WaitForSeconds(delay);
            
            Rigidbody.bodyType = RigidbodyType2D.Kinematic;
            Rigidbody.velocity = new Vector2(0, -fallSpeed);

            yield return new WaitForSeconds(5);

            Rigidbody.bodyType = RigidbodyType2D.Static;
            Rigidbody.velocity = Vector2.zero;
        }

        public override void Reset()
        {
            Rigidbody.velocity = Vector2.zero;
            Rigidbody.bodyType = RigidbodyType2D.Static;

            Position = startPosition;
            
            StopCoroutine(ScheduledFalling());
        }
    }
}