using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class ListExtensions
    {
        public static void AddIfNotContains<T>(this IList<T> list, T element)
        {
            if (list == null || list.Contains(element))
            {
                return;
            }

            list.Add(element);
        }

        public static void AddRange<T>(this IList<T> list, IReadOnlyList<T> otherEnumerable, int count)
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(otherEnumerable[i]);
            }
        }

        public static void ForEach<T>(this IList<T> self, Action<T, int> action)
        {
            for (int i = 0; i < self.Count; i++)
            {
                action(self[i], i);
            }
        }

        public static int IndexOfParentItem<TParent, TChild>(this IList<TChild> self, TParent item)
        {
            if (item is TChild downCastedItem)
            {
                return self.IndexOf(downCastedItem);
            }
            else
            {
                return -1;
            }
        }

        public static void InsertParentItem<TParent, TChild>(this IList<TChild> self, int index, TParent item)
        {
            if (item is TChild downCastedItem)
            {
                self.Insert(index, downCastedItem);
            }
        }

        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static void RemoveRange<T>(this IList<T> list, IEnumerable<T> elementsToRemove)
        {
            foreach (T element in elementsToRemove.Where(list.Contains))
            {
                list.Remove(element);
            }
        }

        public static void Replace<T>(this IList<T> list, T current, T replacement)
        {
            int index = list.IndexOf(current);
            if (index >= 0)
            {
                list[index] = replacement;
            }
        }

        public static void ReplaceContent<T>(
            this IList<T> self, IEnumerable<T> other)
        {
            self.Clear();
            self.AddRange(other);
        }

        public static void SafeForEach<T>(this IList<T> list, Action<T> action, bool removeNullElements = true)
        {
            if (list.IsNullOrEmpty())
            {
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == null)
                {
                    if (removeNullElements)
                    {
                        list.RemoveAt(i);
                    }

                    continue;
                }

                action?.Invoke(list[i]);
            }
        }

        public static void SafeRemove<T>(this IList<T> list, T element)
        {
            if (list.IsNullOrEmpty())
            {
                return;
            }

            if (list.Contains(element))
            {
                list.Remove(element);
            }
        }

        public static void Shuffle<T>(this IList<T> self)
        {
            int GetRandomIndex(int i)
            {
                return UnityEngine.Random.Range(0, i + 1);
            }

            self.Shuffle(GetRandomIndex);
        }

        public static void Shuffle<T>(this IList<T> self, Func<int, int> randomIndexFunc)
        {
            for (int i = self.Count - 1; i > 0; i--)
            {
                int randomIndex = randomIndexFunc(i);

                (self[i], self[randomIndex]) = (self[randomIndex], self[i]);
            }
        }

        public static void Shuffle<T>(this IList<T> self, System.Random random)
        {
            int GetRandomIndex(int i)
            {
                return random.Next(0, i + 1);
            }

            self.Shuffle(GetRandomIndex);
        }
    }
}