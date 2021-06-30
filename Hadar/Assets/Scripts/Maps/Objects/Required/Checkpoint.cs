using Extension;
using UnityEngine;

namespace Maps.Objects.Required
{
    /// <summary>
    /// Represent a checkpoint
    /// </summary>
    public class Checkpoint : TransparentMapObject
    {
        /// <summary>
        /// Spawn point of this checkpoint
        /// </summary>
        public Vector2 SpawnPoint { get; private set; }

        private Animator animator;
        private GameManager gameManager;
        
        private bool reached;
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
            gameManager = GetSceneObject<GameManager>();
            
            SpawnPoint = new Vector2
            {
                x = Position.x - 0.8f,
                y = Position.y - 2
            };
        }

        protected override void OnCollision(Collider2D other)
        {
            if (!other.IsPlayer())
            {
                return;
            }
            
            if (reached)
            {
                return;
            }

            reached = true;
            gameManager.Checkpoint = this;
            
            animator.SetBool("reached", reached);
        }
    }
}