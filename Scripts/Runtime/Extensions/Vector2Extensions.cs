using System.Collections.Generic;
using UnityEngine;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class Vector2Extensions
    {
        public static int Compare(this Vector2 self, Vector2 other)
        {
            if (self.x > other.x && self.y > other.y)
            {
                return 1;
            }

            if (self.x < other.x && self.y < other.y)
            {
                return -1;
            }

            return 0;
        }

        public static float Random(this Vector2 self)
        {
            return UnityEngine.Random.Range(self.x, self.y);
        }

        public static Vector3 PointerAs3dPosition(this Vector2 pointerPosition, Camera camera = null)
        {
            if (!camera)
            {
                camera = Camera.main;
            }

            Vector3 worldPoint = camera.ScreenToWorldPoint(pointerPosition);
            return worldPoint;
        }

        public static Vector2 RandomPointInRing(this Vector2 origin, float minRadius, float maxRadius)
        {
            Vector2 v = UnityEngine.Random.insideUnitCircle;
            return origin + (v.normalized * minRadius + v * (maxRadius - minRadius));
        }

        public static IEnumerable<Vector2> PointsAround(this Vector2 center, int count, float radius)
        {
            for (int i = 0; i < count; i++)
            {
                float radians = 2 * Mathf.PI / count * i;

                float horizontalDir = Mathf.Sin(radians);
                float verticalDir = Mathf.Cos(radians);

                Vector2 spawnDir = new Vector2(verticalDir, horizontalDir);

                yield return center + spawnDir * radius;
            }
        }

        public static bool IsNearTo(this Vector2 origin, Vector2 target, float nearDistance)
        {
            return Vector2.Distance(origin, target) <= nearDistance;
        }

        public static Vector2 RandomPointInAnnulus(this Vector2 origin, float minRadius, float maxRadius)
        {
            Vector2 randomDirection = (UnityEngine.Random.insideUnitCircle * origin).normalized;
            float randomDistance = UnityEngine.Random.Range(minRadius, maxRadius);
            Vector2 point = origin + randomDirection * randomDistance;

            return point;
        }

        public static bool Contains(
            this Vector2 self,
            float value,
            bool minInclusive = true,
            bool maxInclusive = true)
        {
            bool isGreaterThanMin = false;
            if (minInclusive)
            {
                isGreaterThanMin = self.x <= value;
            }
            else
            {
                isGreaterThanMin = self.x < value;
            }

            bool isLesserThanMax = false;
            if (maxInclusive)
            {
                isLesserThanMax = self.y >= value;
            }
            else
            {
                isLesserThanMax = self.y > value;
            }

            return isGreaterThanMin && isLesserThanMax;
        }
    }
}