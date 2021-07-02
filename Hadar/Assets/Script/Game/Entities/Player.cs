using System;
using System.Collections;
using Script.Controller;
using Script.Extension;
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
        
        public bool IsDead { get; private set; }

        public void Bump(Vector2 vector)
        {
            controller.AddForce(vector);
        }

        public void Kill()
        {
            if (IsDead)
            {
                return;
            }

            IsDead = true;
            
            StartCoroutine(ExecuteWithTransition(() =>
            {
                GameManager.Map.ResetTraps();
                
                SpriteRenderer.flipX = false;
                Position = GameManager.LastCheckpoint != null 
                    ? GameManager.LastCheckpoint.SpawnPoint 
                    : GameManager.Map.Spawn.SpawnPoint;

                IsDead = false;
            }));
        }

        public void Teleport(Vector2 destination)
        {
            StartCoroutine(ExecuteWithTransition(() =>
            {
                Position = destination;
            }));
        }
        
        private IEnumerator ExecuteWithTransition(Action action, bool withPlayer = true)
        {
            if (withPlayer)
            {
                controller.Freeze = true;
                yield return Animator.TriggerAndWait("disappear");
            }
            
            yield return GameManager.Scene.FadeOut();

            action();

            yield return GameManager.Scene.FadeIn();

            if (withPlayer)
            {
                yield return Animator.TriggerAndWait("appear");
                controller.Freeze = false;
            }
        }
        
        
    }
}