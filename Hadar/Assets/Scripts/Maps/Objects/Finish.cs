using UnityEngine;

namespace Maps.Objects
{
    /// <summary>
    /// Represent the finish line of a map
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class Finish : MapObject
    {
        private Animator animator;
        private GameManager gameManager;

        private bool reached;
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
            gameManager = GetSceneObject<GameManager>();
        }

        protected override void OnTopCollisionWithPlayer()
        {
            if (reached)
            {
                return;
            }

            reached = true;
            gameManager.ChangeLevel();
            
            animator.SetBool("reached", reached);
        }
    }
}