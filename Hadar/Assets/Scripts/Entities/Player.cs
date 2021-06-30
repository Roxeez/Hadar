using System;
using UnityEngine;

namespace Entities
{
    /// <summary>
    /// Represent our Player
    /// </summary>
    public class Player : PhysicsEntity
    {
        [SerializeField] private float speed = 7f;
        [SerializeField] private float jumpSpeed = 7f;

        /// <summary>
        /// Define if player is moving or not
        /// </summary>
        public bool IsMoving => Math.Abs(Velocity.x) > 0.01f;
        
        /// <summary>
        /// Define if player is jumping or not
        /// </summary>
        public bool IsJumping => !IsCollidingWithGround && Velocity.y > 0;
        
        /// <summary>
        /// Define if player is falling or not
        /// </summary>
        public bool IsFalling => !IsCollidingWithGround && Velocity.y < 0;
        
        /// <summary>
        /// Define if sprite is flipped or not (on x axis)
        /// </summary>
        public bool IsFlipped => spriteRenderer.flipX;

        /// <summary>
        /// Define if player has double jumped
        /// </summary>
        public bool HasDoubleJumped { get; private set; }
        
        /// <summary>
        /// Define if player can move
        /// </summary>
        public bool CanMove { get; set; }
        
        /// <summary>
        /// Current position of this player
        /// </summary>
        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

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

        /// <summary>
        /// Flip player sprite on x axis
        /// </summary>
        public void Flip()
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        /// <summary>
        /// Make this player move with a defined power
        /// </summary>
        /// <param name="power">Movement power</param>
        public void Move(float power)
        {
            if (power < -0.1f)
            {
                if (!IsFlipped)
                {
                    Flip();
                }
            }
            else if (power > 0.1f)
            {
                if (IsFlipped)
                {
                    Flip();
                }
            }

            Velocity.x = power * speed;
        }

        /// <summary>
        /// Make this player idle
        /// </summary>
        public void Idle()
        {
            Velocity.x = 0;
        }

        /// <summary>
        /// Make this player jump with a defined power
        /// </summary>
        /// <param name="power">Jump power</param>
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
            var horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput > -0.1f && horizontalInput < 0.1f || !CanMove)
            {
                Idle();
            }
            
            if (CanMove)
            {
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
