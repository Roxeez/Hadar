using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;
    
    private Animator animator;
    
    public bool IsTaken { get; private set; }
    
    private static readonly int TakenAnimatorId = Animator.StringToHash("taken");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!IsTaken)
            {
                IsTaken = true;
                levelManager.LastCheckpoint = this;
            }
        }
        
        animator.SetBool(TakenAnimatorId, true);
    }
}
