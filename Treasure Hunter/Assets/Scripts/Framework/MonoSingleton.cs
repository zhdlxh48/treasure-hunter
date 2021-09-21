﻿using UnityEngine;

/// <summary>
/// Inherit from this base class to create a singleton.
/// e.g. public class MyClassName : Singleton<MyClassName> {}
/// </summary>

namespace Core
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Check to see if we're about to be destroyed.
        private static bool ShuttingDown = false;
        private static object Lock = new object();
        private static T instance;

        /// <summary>
        /// Access singleton instance through this propriety.
        /// </summary>
        
        public static T Instance
        {
            get
            {
                if (ShuttingDown)
                {
                    Debug.LogWarning("[Singleton] Instance " + typeof(T) +
                        " already destroyed. Returning null.");
                    return null;
                }

                lock (Lock)
                {
                    if (instance == null)
                    {
                        // Search for existing instance.
                        var list = FindObjectOfType(typeof(T)) as T;

                        // Create new instance if one doesn't already exist.
                        if (instance == null)
                        {
                            // Need to create a new GameObject to attach the singleton to.
                            var singletonObject = new GameObject();
                            instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).ToString() + " (Singleton)";

                            // Make instance persistent.
                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return instance;
                }
            }
        }

        private void OnApplicationQuit()
        {
            ShuttingDown = true;
        }

        private void OnDestroy()
        {
            ShuttingDown = true;
        }

        protected virtual void Awake()
        {
            instance = this as T;
        }
    }
}