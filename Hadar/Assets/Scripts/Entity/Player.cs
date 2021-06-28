using System;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : PhysicsEntity
    {
        [SerializeField] private float speed = 7f;
        [SerializeField] private float jumpSpeed = 7f;

        public bool IsMoving => Math.Abs(Velocity.x) > 0.01f;
        public bool IsJumping => !IsCollidingWithGround && Velocity.y > 0;
        public bool IsFalling => !IsCollidingWithGround && Velocity.y < 0;
        public bool IsFlipped => spriteRenderer.flipX;

        public bool HasDoubleJumped { get; private set; }
        public bool CanMove { get; set; }

        private Animator animator;
        private SpriteRenderer spriteRenderer;

        private static readonly int MoveAnimatorId = Animator.StringToHash("move");
        private static readonly int JumpAnimatorId = Animator.StringToHash("jump");
        private static readonly int FallAnimatorId = Animator.StringToHash("fall");
        private static readonly int DoubleJumpAnimatorId = Animator.StringToHash("double jump");

        protected override void Awake()
        {
            base.Awake();
        
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            CanMove = true;
        }

        public void Flip()
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        public void Move(float power)
        {
            if (power < -0.1f)
            {
                if (!spriteRenderer.flipX)
                {
                    spriteRenderer.flipX = true;
                }
            }
            else if (power > 0.1f)
            {
                if (spriteRenderer.flipX)
                {
                    spriteRenderer.flipX = false;
                }
            }

            Velocity.x = power * speed;
        }

        public void Idle()
        {
            Velocity.x = 0;
        }

        public void Jump(float power = 1f)
        {
            if (IsCollidingWithGround)
            {
                Velocity.y = jumpSpeed * power;
            }
            else
            {
                if (!HasDoubleJumped)
                {
                    Velocity.y = jumpSpeed * power;
                    HasDoubleJumped = true;
                }
            }
        }

        private void Update()
        {
            if (CanMove)
            {
                var horizontalInput = Input.GetAxis("Horizontal");

                if (horizontalInput > -0.1f && horizontalInput < 0.1f)
                {
                    Idle();
                }
        
                if (horizontalInput < -0.1f || horizontalInput > 0.1f)
                {
                    Move(horizontalInput);
                }

                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                }
            }

            if (IsCollidingWithGround)
            {
                HasDoubleJumped = false;
            }

            animator.SetBool(JumpAnimatorId, IsJumping);
            animator.SetBool(MoveAnimatorId, IsMoving);
            animator.SetBool(FallAnimatorId, IsFalling);
            animator.SetBool(DoubleJumpAnimatorId, IsJumping && HasDoubleJumped);
        }
    }
}
