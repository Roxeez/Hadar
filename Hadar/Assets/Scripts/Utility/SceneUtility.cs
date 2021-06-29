using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utility
{
    public static class SceneUtility
    {
        /// <summary>
        /// Get an object of defined type in scene
        /// This method is a shortcut to SceneUtility#GetSceneObject
        /// </summary>
        /// <param name="optional">If this object is optional or not</param>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <exception cref="UnityException">Throw if object is not optional and is not found</exception>
        public static T GetSceneObject<T>(bool optional = false) where T : Object
        {
            var value = Object.FindObjectOfType<T>();
            if (value == default && !optional)
            {
                throw new UnityException($"Can't found required object {typeof(T).Name} in scene");
            }

            return value;
        }

        /// <summary>
        /// Get all objects of defined type in scene
        /// This method is a shortcut to SceneUtility#GetSceneObjects
        /// </summary>
        /// <param name="optional">If this object is optional or not</param>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <exception cref="UnityException">Throw if object is not optional and is not found</exception>
        public static T[] GetSceneObjects<T>(bool optional = false) where T : Object
        {
            var value = Object.FindObjectsOfType<T>();
            if (value == default && !optional)
            {
                throw new UnityException($"Can't found required object {typeof(T).Name} in scene");
            }

            return value ?? Array.Empty<T>();
        }
    }
}