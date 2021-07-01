using UnityEngine;

namespace Script.Utility
{
    public static class Check
    {
        public static void NotNull(object value, string message)
        {
            if (value == null)
            {
                Debug.LogError(message);
            }
        }
    }
}