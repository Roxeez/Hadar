using UnityEngine;

namespace Maps.Objects
{
    /// <summary>
    /// Represent a checkpoint
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class Checkpoint : MapObject
    {
        private Animator animator;
        private GameManager gameManager;

        private bool reached;

        /// <summary>
        /// Spawn point of this checkpoint
        /// </summary>
        public Vector2 SpawnPoint { get; private set; }

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

        protected override void OnCollisionWithPlayer()
        {
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