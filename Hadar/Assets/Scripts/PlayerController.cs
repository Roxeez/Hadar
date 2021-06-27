using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : PhysicObject
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpSpeed = 7f;

    public bool IsMoving => Math.Abs(Velocity.x) > 0.01f;
    public bool IsJumping => !IsCollidingWithGround && Velocity.y > 0;
    public bool IsFalling => !IsCollidingWithGround && Velocity.y < 0;
    public bool IsWallSliding => IsCollidingWithWall && IsFalling;
    
    public bool HasDoubleJumped { get; private set; }

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

    private void Move(float movement)
    {
        if (movement < -0.1f)
        {
            if (!spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;
            }
        }
        else if (movement > 0.1f)
        {
            if (spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            }
        }

        Velocity.x = movement * speed;
    }

    private void Idle()
    {
        Velocity.x = 0;
    }

    private void Jump(float power = 1f)
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
