using System;
using System.Collections.Generic;
using System.Linq;

namespace niscolas.UnityExtensions
{
    public static class EnumerableExtensions
    {
        public static T RandomElement<T>(this IEnumerable<T> source)
        {
            return source.RandomElement(new Random());
        }

        // TODO avoid multiple enumeration
        public static T RandomElement<T>(this IEnumerable<T> source, Random random)
        {
            int index = random.Next(0, source.Count());
            return source.ElementAt(index);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T element in enumerable)
            {
                action?.Invoke(element);
            }
        }

        public static bool IsValid<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return false;
            }

            T[] array = enumerable.ToArray();

            if (array.Length == 0)
            {
                return false;
            }

            bool isValid = array.All(element => element != null);
            return isValid;
        }

        public static int RandomElementCount<T>(this IReadOnlyList<T> readOnlyList, int min = 0, int max = -1)
        {
            if (max == -1)
            {
                max = readOnlyList.Count;
            }
            return UnityEngine.Random.Range(min, max);
        }

        public static IEnumerable<T> RandomUniqueElementsWithCount<T>(this IEnumerable<T> enumerable, int elementCount)
        {
            return enumerable.OrderBy(arg => Guid.NewGuid()).Take(elementCount);
        }

        public static IEnumerable<T> RandomUniqueElements<T>(this IEnumerable<T> enumerable, int min = 0, int max = -1)
        {
            T[] array = enumerable.ToArray();
            int randomElementCount = array.RandomElementCount(min, max);
            IEnumerable<T> result = array.RandomUniqueElementsWithCount(randomElementCount);

            return result;
        }

        public static bool ContainsAll<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB)
        {
            return enumerableB.All(element => enumerableA.Contains(element));
        }

        public static bool ContainsAny<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB)
        {
            return enumerableA.Intersect(enumerableB).Any();
        }
    }
}

