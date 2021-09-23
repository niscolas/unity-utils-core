﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.Utilities;
using UnityEngine;

namespace niscolas.UnityExtensions
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