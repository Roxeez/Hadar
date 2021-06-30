using System;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;

namespace Maps.Objects
{
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
        

        /// <summary>
        /// Method called when an collider collide with this object
        /// </summary>
        /// <param name="other">Collider colliding with this object</param>
        protected abstract void OnCollision(Collider2D other);
        
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