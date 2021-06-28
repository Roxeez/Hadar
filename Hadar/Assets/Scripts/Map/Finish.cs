using System;
using UnityEngine;

namespace Map
{
    [RequireComponent(typeof(Animator))]
    public class Finish : MonoBehaviour
    {
        public event Action Reached;

        private static readonly int ReachedAnimatorId = Animator.StringToHash("reached");

        private bool reached;
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            if (reached)
            {
                return;
            }
            
            reached = true;
            animator.SetBool(ReachedAnimatorId, reached);
            
            Reached?.Invoke();
        }
    }
}
