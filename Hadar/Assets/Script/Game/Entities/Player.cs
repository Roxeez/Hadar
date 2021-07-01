using System;
using System.Collections;
using Script.Controller;
using UnityEngine;

namespace Script.Game.Entities
{
    public sealed class Player : Entity
    {
        private PlayerController controller;

        protected override void OnAwake()
        {
            controller = GetComponent<PlayerController>();
        }
        
        public int Health { get; private set; }

        private void Start()
        {
            Health = 3;
        }

        public void Bump(float power)
        {
            controller.AddForce(new Vector2
            {
                y = power
            });
        }

        public void Freeze(bool value)
        {
            controller.Freeze(value);
        }

        public void Hit()
        {
            Health--;
            Animator.SetTrigger("hit");

            if (Health == 0)
            {
                Kill();
            }
        }

        public void Kill()
        {
            StartCoroutine(KillCoroutine());
        }

        private IEnumerator KillCoroutine()
        {
            Freeze(true);
            
            Animator.SetTrigger("disappear");
            yield return new WaitForSeconds(0.75f);
            
            Health = 3;
            SpriteRenderer.flipX = false;
            
            Position = GameManager.LastCheckpoint != null
                ? GameManager.LastCheckpoint.SpawnPoint
                : GameManager.Map.Spawn.SpawnPoint;
            
            Animator.SetTrigger("appear");
            yield return new WaitForSeconds(0.50f);
            
            Freeze(false);
        }
    }
}