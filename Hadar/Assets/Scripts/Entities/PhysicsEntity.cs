using UnityEngine;

namespace Entities
{
    /// <summary>
    /// Represent an entity with physics applied to it
    /// </summary>
    public abstract class PhysicsEntity : MonoBehaviour
    {
        [SerializeField]
        private float gravityMultiplier = 4f;

        /// <summary>
        /// Velocity of this entity
        /// </summary>
        public Vector2 Velocity;
    
        /// <summary>
        /// Define if this entity is colliding with ground
        /// </summary>
        protected bool IsCollidingWithGround { get; private set; }
        
        /// <summary>
        /// Define if this entity is colliding with a wall
        /// </summary>
        protected bool IsCollidingWithWall { get; private set; }
    
        private Rigidbody2D rb;
        private ContactFilter2D contactFilter;
    
        private Vector2 ground;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            
            contactFilter.useTriggers = false;
            contactFilter.useLayerMask = true;
            contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        }

        private void FixedUpdate()
        {
            Velocity += Physics2D.gravity * (gravityMultiplier * Time.deltaTime);

            IsCollidingWithGround = false;
            IsCollidingWithWall = false;

            var delta = Velocity * Time.deltaTime;
            var move = delta.x * new Vector2
            {
                x = ground.y,
                y = -ground.x
            };
        
            Move(move, false);
            move = Vector2.up * delta.y;
            Move(move, true);
        }

        private void Move(Vector2 move, bool verticalMovement)
        {
            var distance = move.magnitude;

            if (distance > 0.01f)
            {
                var hits = new RaycastHit2D[16];
                var hitCount = rb.Cast(move, contactFilter, hits, distance + 0.01f);
            
                for (var i = 0; i < hitCount; i++)
                {
                    var hit = hits[i];
        
                    var current = hit.normal;
                    if (current.y > 0.75f)
                    {
                        IsCollidingWithGround = true;
                        if (verticalMovement)
                        {
                            ground = current;
                            current.x = 0;
                        }
                    }

                    if (current.x > 0.75f || current.x < -0.75f)
                    {
                        IsCollidingWithWall = true;
                    }

                    var projection = Vector2.Dot(Velocity, current);
                    if (projection < 0)
                    {
                        Velocity -= projection * current;
                    }

                    var modifiedDistance = hit.distance - 0.01f;
                    distance = modifiedDistance < distance ? modifiedDistance : distance;
                }

                rb.position += move.normalized * distance;
            }
        }
    }
}
