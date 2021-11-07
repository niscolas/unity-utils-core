using System;
using System.Reflection;
using niscolas.UnityExtensions;
using niscolas.UnityUtils.Core;

namespace niscolasPlugins.UnityUtils.Core
{
    public static class TypeUtility
    {
        public static bool TryFindTypeWithLogs(
            string fullTypeName, out Type type, params Assembly[] assembliesToSearch)
        {
            bool foundType = TryFindType(fullTypeName, out type, assembliesToSearch);
            if (foundType)
            {
                TheBugger.LogSuccess($"the type for {fullTypeName} was found: {type.Name} :D");
            }
            else
            {
                TheBugger.LogRealWarning($"the type for {fullTypeName} wasn't found :(");
            }

            return foundType;
        }

        public static bool TryFindType(
            string fullTypeName, out Type type, params Assembly[] assembliesToSearch)
        {
            type = null;

            if (assembliesToSearch.IsNullOrEmpty())
            {
                assembliesToSearch = AppDomain.CurrentDomain.GetAssemblies();
            }

            foreach (Assembly assembly in assembliesToSearch)
            {
                type = assembly.GetType(fullTypeName);

                if (type != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}