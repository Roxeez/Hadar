using System;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;

namespace Maps.Objects
{
    /// <summary>
    /// Represent a map object how can collide with player (checkpoint, finish, entities)
    /// </summary>
    public abstract class MapObject : MonoBehaviour
    {
        /// <summary>
        /// Current position of this object
        /// </summary>
        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                OnCollisionWithPlayer();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var collider2d = other.collider;
            if (!collider2d.CompareTag("Player"))
            {
                return;
            }

            var contact = other.contacts[0].normal;
            if (contact.y < 0)
            {
                OnTopCollisionWithPlayer();
            }

            OnCollisionWithPlayer();
        }

        /// <summary>
        /// This method is called when player collide with this object
        /// </summary>
        protected virtual void OnCollisionWithPlayer()
        {
            
        }

        /// <summary>
        /// This method is called when player collide with this object on the top edge
        /// It will not be executed if Collider2D is set to IsTrigger
        /// </summary>
        protected virtual void OnTopCollisionWithPlayer()
        {
            
        }

        /// <summary>
        /// Get an object of defined type in scene
        /// This method is a shortcut to SceneUtility#GetSceneObject
        /// </summary>
        /// <param name="optional">If this object is optional, if not an exception will be throw if missing</param>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <returns>Object found or null if optional and not found</returns>
        protected static T GetSceneObject<T>(bool optional = false) where T : Object
        {
            return SceneUtility.GetSceneObject<T>(optional);
        }

        /// <summary>
        /// Get all objects of defined type in scene
        /// This method is a shortcut to SceneUtility#GetSceneObjects
        /// </summary>
        /// <param name="optional">If this object is optional, if not an exception will be throw if missing</param>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <returns>Objects found or null if optional and not found</returns>
        protected static T[] GetSceneObjects<T>(bool optional = false) where T : Object
        {
            return SceneUtility.GetSceneObjects<T>(optional);
        }
    }
}