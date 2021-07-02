using System;
using UnityEngine;

namespace Script.Controller
{
    public sealed partial class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpSpeed;

        private Rigidbody2D rb;
        private Animator animator;
        private SpriteRenderer spriteRenderer;
        
        private bool doubleJumped;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public bool CanMove { get; set; } = true;

        private bool freeze;
        public bool Freeze
        {
            get => freeze;
            set
            {
                if (value)
                {
                    rb.bodyType = RigidbodyType2D.Static;
                    CanMove = false;
                }
                else
                {
                    rb.bodyType = RigidbodyType2D.Kinematic;
                    CanMove = true;
                }

                freeze = value;
            }
        }

        public void AddForce(Vector2 force)
        {
            velocity += force;
        }

        private void Start()
        {
            contactFilter.useTriggers = false;
            contactFilter.useLayerMask = true;
            contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        }

        private void Update()
        {
            var horizontal = 0f;
            var jump = false;

            if (CanMove)
            {
                horizontal = Input.GetAxis("Horizontal");
                jump = Input.GetButtonDown("Jump");
            }

            if (jump)
            {
                if (grounded)
                {
                    velocity.y = jumpSpeed;
                }
                else if (!doubleJumped)
                {
                    velocity.y = jumpSpeed;
                    
                    doubleJumped = true;
                    animator.SetTrigger("double jump");
                }
            }

            velocity.x = Mathf.Abs(horizontal) > 0.1f ? horizontal * movementSpeed : 0;

            if (grounded)
            {
                doubleJumped = false;
            }
            
            spriteRenderer.flipX = velocity.x != 0 ? velocity.x < -0.1f : spriteRenderer.flipX;

            animator.SetFloat("x", Mathf.Abs(velocity.y) < 0.1f ? velocity.x : 0);
            animator.SetFloat("y", velocity.y);
        }
    }
}