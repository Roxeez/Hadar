using System;
using Extension;
using UnityEngine;

namespace Maps.Objects.Traps
{
    public class Trampoline : SolidMapObject
    {
        [SerializeField]
        private float power;

        private Animator animator;
        private GameManager gameManager;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            gameManager = GetSceneObject<GameManager>();
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

            animator.SetTrigger("Triggered");
            
            gameManager.Player.Jump(power);
        }
    }
}