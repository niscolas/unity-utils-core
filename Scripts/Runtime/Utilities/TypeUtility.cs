using System;
using System.Reflection;
using niscolas.UnityExtensions;
using niscolas.UnityUtils.Core;

namespace niscolasPlugins.UnityUtils.Core
{
    public static class TypeUtility
    {
        public static bool TryFindType(
            string fullTypeName, out Type type, params Assembly[] assembliesToSearch)
        {
            type = null;
            if (string.IsNullOrEmpty(fullTypeName))
            {
                TheBugger.LogRealWarning("the input type was null or empty");
                return false;
            }

            if (assembliesToSearch.IsNullOrEmpty())
            {
                assembliesToSearch = AppDomain.CurrentDomain.GetAssemblies();
            }

            foreach (Assembly assembly in assembliesToSearch)
            {
                type = assembly.GetType(fullTypeName);

                if (type != null)
                {
                    TheBugger.LogSuccess($"the type for {fullTypeName} was found: {type.Name} :D");
                    return true;
                }
            }

            TheBugger.LogRealWarning($"the type for {fullTypeName} wasn't found :(");
            return false;
        }
    }
}