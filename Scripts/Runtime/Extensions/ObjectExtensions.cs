using System;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsDefault(this object obj)
        {
            return obj.Equals(default);
        }

        public static bool TryDoAsCasted<TCurrent, TCasted>(
            this TCurrent self, Action<TCasted> callback)
        {
            if (self is TCasted casted)
            {
                callback(casted);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}