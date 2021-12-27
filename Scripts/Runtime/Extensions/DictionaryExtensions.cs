using System.Collections.Generic;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddManyKeys<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            IEnumerable<TKey> keys,
            TValue value)
        {
            foreach (TKey key in keys)
            {
                if (dictionary.ContainsKey(key))
                {
                    continue;
                }

                dictionary.Add(key, value);
            }
        }
    }
}