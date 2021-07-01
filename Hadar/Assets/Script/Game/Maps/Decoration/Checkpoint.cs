using Script.Enum;
using Script.Extension;
using UnityEngine;

namespace Script.Game.Maps.Decoration
{
    public class Checkpoint : MapObject
    {
        [SerializeField] private Vector2 offset;
        
        public bool IsReached { get; private set; }
        public Vector2 SpawnPoint { get; private set; }
        
        private void Start()
        {
            SpawnPoint = new Vector2
            {
                x = Position.x + offset.x,
                y = Position.y + offset.y
            };
        }

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