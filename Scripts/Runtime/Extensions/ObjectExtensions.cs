namespace niscolas.UnityUtils.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsDefault(this object obj)
        {
            return obj.Equals(default);
        }
    }
}