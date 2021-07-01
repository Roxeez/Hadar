using Script.Enum;
using UnityEngine;

namespace Script.Game.Maps
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class MapObject : MonoBehaviour
    {
        private void Awake()
        {
            Animator = GetComponent<Animator>();
            Collider = GetComponent<BoxCollider2D>();
            Rigidbody = GetComponent<Rigidbody2D>();
            GameManager = FindObjectOfType<GameManager>();
            
            OnAwake();
        }
        
        protected Animator Animator { get; private set; }
        protected Rigidbody2D Rigidbody { get; private set; }
        protected Collider2D Collider { get; private set; }
        protected GameManager GameManager { get; private set; }
        
        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        protected virtual void OnAwake()
        {
            
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var side = CollisionSide.Undefined;

            if (other.contacts.Length > 0)
            {
                var contact = other.contacts[0].normal;

                if (Mathf.Abs(contact.y) > Mathf.Abs(contact.x))
                {
                    side = contact.y < 0 ? CollisionSide.Top : CollisionSide.Bottom;
                }
                else
                {
                    side = contact.x < 0 ? CollisionSide.Left : CollisionSide.Right;
                }
            }
            
            OnCollision(other.collider, side);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnCollision(other, CollisionSide.Undefined);
        }

        protected virtual void OnCollision(Collider2D other, CollisionSide side)
        {

        }
        
        protected virtual void Reset()
        {
            
        }
    }
}