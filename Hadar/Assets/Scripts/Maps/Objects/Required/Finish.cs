using Extension;
using UnityEngine;

namespace Maps.Objects.Required
{
    /// <summary>
    /// Represent the finish line of a map
    /// </summary>
    public class Finish : SolidMapObject
    {
        private Animator animator;
        private GameManager gameManager;

        private bool reached;
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
            gameManager = GetSceneObject<GameManager>();
        }

        protected override void OnCollision(Collider2D other, CollisionSide side)
        {
            if (side != CollisionSide.Top)
            {
                return;
            }

            if (!other.IsPlayer())
            {
                return;
            }
            
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