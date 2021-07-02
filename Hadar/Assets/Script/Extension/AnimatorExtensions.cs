using System.Collections;
using UnityEngine;

namespace Script.Extension
{
    public static class AnimatorExtensions
    {
        public static IEnumerator TriggerAndWait(this Animator animator, string trigger)
        {
            animator.SetTrigger(trigger);

            var state = animator.GetCurrentAnimatorStateInfo(0);
            yield return new WaitForSeconds(state.length);
        }
    }
}