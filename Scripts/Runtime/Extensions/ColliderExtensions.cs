using UnityEngine;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class ColliderExtensions
    {
        public static Vector3 GetRandomPoint(this Collider collider)
        {
            Bounds bounds = collider.bounds;

            Vector3 point = new(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );

            if (point != collider.ClosestPoint(point))
            {
                point = GetRandomPoint(collider);
            }

            return point;
        }

        public static void GetReliableBounds(this Collider collider, out Bounds bounds)
        {
            bool initialState = collider.enabled;
            collider.enabled = true;
            bounds = collider.bounds;
            collider.enabled = initialState;
        }
    }
}