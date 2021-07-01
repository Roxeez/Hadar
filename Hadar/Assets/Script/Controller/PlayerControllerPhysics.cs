using UnityEngine;

namespace Script.Controller
{
    public sealed partial class PlayerController
    {
        [SerializeField] private float gravity;
        
        private Vector2 velocity;
        private Vector2 ground;
        private ContactFilter2D contactFilter;
        
        private bool grounded;
        
        private void FixedUpdate()
        {
            velocity += Physics2D.gravity * (gravity * Time.deltaTime);

            grounded = false;
            
            var delta = velocity * Time.deltaTime;
            var movement = delta.x * new Vector2
            {
                x = ground.y,
                y = -ground.x
            };
            
            Move(movement, false);
            movement = Vector2.up * delta.y;
            Move(movement, true);
        }

        private void Move(Vector2 movement, bool vertical)
        {
            var distance = movement.magnitude;
            if (!(distance > 0.01f))
            {
                return;
            }
            
            var hits = new RaycastHit2D[16];
            var hitCount = rb.Cast(movement, contactFilter, hits, distance + 0.01f);
            for (var i = 0; i < hitCount; i++)
            {
                var hit = hits[i];

                var current = hit.normal;
                if (current.y > 0.75f)
                {
                    grounded = true;
                    if (vertical)
                    {
                        ground = current;
                        current.x = 0;
                    }
                }

                var projection = Vector2.Dot(velocity, current);
                if (projection < 0)
                {
                    velocity -= projection * current;
                }

                var modifiedDistance = hit.distance - 0.01f;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

            rb.position += movement.normalized * distance;
        }
    }
}