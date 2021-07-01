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

        public void Bump(float power)
        {
            controller.AddForce(new Vector2
            {
                y = power
            });
        }

        public void Kill()
        {
            StartCoroutine(KillCoroutine());
        }

        private IEnumerator KillCoroutine()
        {
            controller.Freeze(true);
            
            Animator.SetTrigger("disappear");
            yield return new WaitForSeconds(0.75f);
            
            Position = GameManager.LastCheckpoint != null
                ? GameManager.LastCheckpoint.SpawnPoint
                : GameManager.Map.Spawn.SpawnPoint;

            SpriteRenderer.flipX = false;
            
            Animator.SetTrigger("appear");
            yield return new WaitForSeconds(0.50f);
            
            controller.Freeze(false);
        }
    }
}