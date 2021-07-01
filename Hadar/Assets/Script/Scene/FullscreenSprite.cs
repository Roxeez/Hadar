using System;
using UnityEngine;

namespace Script.Scene
{
    [ExecuteInEditMode]
    public class FullscreenSprite : MonoBehaviour
    {
        [SerializeField]
        private Camera cam;
        
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            transform.localScale = new Vector3(1,1,1);
     
            var width = spriteRenderer.sprite.bounds.size.x;
            var height = spriteRenderer.sprite.bounds.size.y;
     
            var worldScreenHeight = cam.orthographicSize * 2.0;
            var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            transform.localScale = new Vector3
            {
                x = (float)worldScreenWidth / width,
                y = (float)worldScreenHeight / height
            };
        }
    }
}