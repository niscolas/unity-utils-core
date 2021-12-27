using System.Collections.Generic;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [SelectionBase]
    public class Root : MonoBehaviour
    {
        private static readonly HashSet<GameObject> RootGameObjects = new();

        private void Awake()
        {
            RootGameObjects.Add(gameObject);
        }

        private void OnDestroy()
        {
            RootGameObjects.Remove(gameObject);
        }

        public static bool CheckIsRoot(GameObject testGameObject)
        {
            return RootGameObjects.Contains(testGameObject);
        }
    }
}