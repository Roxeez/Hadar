using System;
using System.Collections;
using Extension;
using UnityEngine;

namespace Maps.Objects.Traps
{
    public class FallingPlatform : SolidMapObject
    {
        private Map map;
        private Rigidbody2D rb;
        private Collider2D col;
        private Animator animator;
        
        private Vector2 startingPosition;

        [SerializeField]
        private float fallSpeed = 15.0f;

        private void Awake()
        {
            map = GetSceneObject<Map>();
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            startingPosition = transform.position;
            
            Physics2D.IgnoreCollision(col, map.Terrain.Collider);
            Physics2D.IgnoreCollision(col, map.Border.Collider);
        }

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
            
            StartCoroutine(ScheduledFalling());
        }

        private IEnumerator ScheduledFalling()
        {
            animator.SetTrigger("Triggered");
            
            yield return new WaitForSeconds(1);

            rb.isKinematic = false;
            rb.velocity = new Vector2(0, -fallSpeed);
        }

        public void Reset()
        {
            animator.Play("On");
            
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;

            transform.position = startingPosition;
        }
    }
}
