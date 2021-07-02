using Script.Enum;
using Script.Extension;
using UnityEngine;

namespace Script.Game.Maps.Decoration
{
    public class Checkpoint : MapObject
    {
        protected override void OnAwake()
        {
            SpawnPoint = new Vector2
            {
                x = Position.x + 0.75f,
                y = Position.y - 2f
            };
        }
        
        public bool IsReached { get; private set; }
        public Vector2 SpawnPoint { get; private set; }

        protected override void OnCollision(Collider2D other, CollisionSide side)
        {
            if (!other.IsPlayer() || IsReached)
            {
                return;
            }

            IsReached = true;
            GameManager.LastCheckpoint = this;
            
            Animator.SetTrigger("animate");
        }
    }
}