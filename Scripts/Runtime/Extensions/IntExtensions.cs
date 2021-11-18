using System;
using System.Collections.Generic;
using UnityEngine;

namespace niscolas.UnityExtensions
{
    public static class IntExtensions
    {
        public static bool IsValidIndex(this int i, int length)
        {
            return i >= 0 && i < length;
        }

        public static int FlattenIndex(this ValueTuple<int, int> index2d, int width)
        {
            (int row, int col) = index2d;
            int flattenedIndex = width * row + col;
            return flattenedIndex;
        }

        public static bool BitmaskEnumContainsValue<T>(this T bitmaskEnum, T value) where T : Enum
        {
            int valueAsInt = Convert.ToInt32(value);
            return (Convert.ToInt32(bitmaskEnum) & valueAsInt) == valueAsInt;
        }

        public static IEnumerable<int> EnumerableFor(this int from, int to)
        {
            if (from < to)
            {
                for (int i = from; i < to; i++)
                {
                    yield return i;
                }
            }
            else
            {
                for (int i = from; i > to; i--)
                {
                    yield return i;
                }
            }
        }

        public static void DoNTimes(this int n, Action<int> action)
        {
            for (int i = 0; i < n; i++)
            {
                action.Invoke(i);
            }
        }
    }
}