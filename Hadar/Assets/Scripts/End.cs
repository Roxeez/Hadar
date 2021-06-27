using UnityEngine;

public class End : MonoBehaviour
{
    private Animator animator;

    private static readonly int FinishedAnimatorId = Animator.StringToHash("finished");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool(FinishedAnimatorId, true);
        }
    }
}
