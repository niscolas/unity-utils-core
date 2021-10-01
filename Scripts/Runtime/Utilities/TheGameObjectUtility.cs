using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core.Editor;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public static class TheGameObjectUtility
    {
        public static GameObject FindOrCreate(string gameObjectName)
        {
            GameObject instance = GameObject.Find(gameObjectName);

            if (!instance)
            {
                instance = new GameObject(gameObjectName);
            }

            return instance;
        }

        public static IEnumerable<ComponentOfInterface<T>> FindObjectsOfInterfaceAsComponents<T>()
            where T : class
        {
            return Object.FindObjectsOfType<Component>()
                .Where(c => c is T)
                .Select(c => new ComponentOfInterface<T>(c, c as T));
        }
    }
}