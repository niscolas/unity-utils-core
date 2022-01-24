using System;
using System.Collections.Generic;
using System.Linq;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool ContainsAll<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB)
        {
            return enumerableB.All(element => enumerableA.Contains(element));
        }

        public static bool ContainsAny<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB)
        {
            return enumerableA.Intersect(enumerableB).Any();
        }

        public static bool ElementsAreEqual<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB)
        {
            return !enumerableA.Except(enumerableB).Any();
        }

        public static T2 FirstOfType<T1, T2>(this IEnumerable<T1> self)
        {
            T2 result = default;
            self.ForEach(x =>
            {
                if (x is T2 t2)
                {
                    result = t2;
                }
            });
            return result;
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T element in enumerable)
            {
                action?.Invoke(element);
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
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

        public static IEnumerable<TOutput> Map<TInput, TOutput>(
            this IEnumerable<TInput> self,
            Func<TInput, TOutput> func)
        {
            foreach (TInput input in self)
            {
                yield return func(input);
            }
        }

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

        public static int RandomElementCount<T>(this IReadOnlyList<T> readOnlyList, int min = 0, int max = -1)
        {
            if (max == -1)
            {
                max = readOnlyList.Count;
            }

            return UnityEngine.Random.Range(min, max);
        }

        public static IEnumerable<T> RandomUniqueElements<T>(this IEnumerable<T> enumerable, int min = 0, int max = -1)
        {
            T[] array = enumerable.ToArray();
            int randomElementCount = array.RandomElementCount(min, max);
            IEnumerable<T> result = array.RandomUniqueElementsWithCount(randomElementCount);

            return result;
        }

        public static IEnumerable<T> RandomUniqueElementsWithCount<T>(this IEnumerable<T> enumerable, int elementCount)
        {
            return enumerable.OrderBy(arg => Guid.NewGuid()).Take(elementCount);
        }

        public static bool TryGetFirstOfType<T1, T2>(this IEnumerable<T1> self, out T2 result)
        {
            result = self.FirstOfType<T1, T2>();
            return !result.IsUnityNull();
        }
    }
}