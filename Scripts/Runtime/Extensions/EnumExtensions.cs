using System;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class EnumExtensions
    {
        public static T Next<T>(this T src) where T : struct
        {
            return src.GetElementWithOffset(+1);
        }

        public static T Previous<T>(this T src) where T : struct
        {
            return src.GetElementWithOffset(-1);
        }

        private static T GetElementWithOffset<T>(this T src, int indexOffset) where T : struct
        {
            Type enumType = typeof(T);

            if (!enumType.IsEnum)
            {
                throw new ArgumentException($"provided value {enumType.FullName} is not an Enum");
            }

            T[] array = (T[]) Enum.GetValues(enumType);
            int index = Array.IndexOf(array, src);
            index += indexOffset;

            T result = array.GetRotatedElementWhenIndexInvalid(index);
            return result;
        }
    }
}