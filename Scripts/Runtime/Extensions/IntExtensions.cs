using System;

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
            return ( Convert.ToInt32(bitmaskEnum)  & valueAsInt) == valueAsInt;
        }
    }
}