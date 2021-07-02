using System.Collections;
using Script.Extension;
using UnityEngine;

namespace Script.Game
{
    public class GameScene : MonoBehaviour
    {
        private Animator animator;
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public IEnumerator FadeIn()
        {
            return animator.TriggerAndWait("fade in");
        }

        public IEnumerator FadeOut()
        {
            return animator.TriggerAndWait("fade out");
        }
    }
}