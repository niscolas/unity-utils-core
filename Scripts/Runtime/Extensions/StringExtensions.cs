using System;
using System.Collections.Generic;
using System.Linq;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class StringExtensions
    {
        public static string WithoutSpaces(this string str)
        {
            return str.Replace(" ", "");
        }

        public static string Without(this string str, string toRemove)
        {
            return str.Replace(toRemove, "");
        }

        public static string SubstringUntilLastCharacter(this string str, char lastCharacter)
        {
            int lastIndex = str.LastIndexOf(lastCharacter);
            string substr = str.Substring(0, lastIndex);
            return substr;
        }

        public static string SubstringFromLastIndexOf(this string str, char value)
        {
            return str.Substring(str.LastIndexOf(value) + 1);
        }

        public static string FromSnakeToCamelCase(this string str)
        {
            return str
                .SplitSnakeCase()
                .Select(s => char.ToLowerInvariant(s[0]) + s.SubstringExceptFirstChar())
                .JoinStrings();
        }

        public static string FromSnakeToPascalCase(this string str)
        {
            return str
                .SplitSnakeCase()
                .Select(s => char.ToUpperInvariant(s[0]) + s.SubstringExceptFirstChar())
                .JoinStrings();
        }

        public static IEnumerable<string> SplitSnakeCase(this string str)
        {
            return str.Split(new[] {"_"}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string SubstringExceptFirstChar(this string str)
        {
            return str.Substring(1, str.Length - 1);
        }

        public static string JoinStrings(this IEnumerable<string> strings)
        {
            return string.Concat(strings);
        }
    }
}