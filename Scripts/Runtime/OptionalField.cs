using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [Serializable]
    public struct OptionalField<T>
    {
        [SerializeField]
        private bool _use;

        [ShowIf(nameof(_use))]
        [SerializeField]
        private T _value;

        public bool TryGetValue(out T value)
        {
            value = _value;

            return _use;
        }
    }
}