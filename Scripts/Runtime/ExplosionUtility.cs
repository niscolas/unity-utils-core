using System.Linq;
using niscolas.UnityExtensions;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public static class ExplosionUtility
    {
        public static void SimpleExplosion(
            Vector3 explosionPosition,
            float targetCheckRadius,
            Collider[] results,
            int layerMask,
            float explosionForce,
            float explosionRadius,
            float upwardsModifier = 0,
            ForceMode forceMode = ForceMode.Force,
            params Collider[] excludedColliders)
        {
            int resultCount = Physics.OverlapSphereNonAlloc(
                explosionPosition, targetCheckRadius, results, layerMask);

            bool shouldExcludeAnyCollider = !excludedColliders.IsNullOrEmpty();

            for (int i = 0; i < resultCount; i++)
            {
                if (results[i] &&
                    (!shouldExcludeAnyCollider || !excludedColliders.Contains(results[i])))
                {
                    ExplodeGameObject(
                        results[i].gameObject,
                        explosionPosition,
                        explosionForce,
                        explosionRadius,
                        upwardsModifier,
                        forceMode);
                }
            }
        }

        public static void ExplodeGameObject(
            GameObject gameObject,
            Vector3 explosionPosition,
            float explosionForce,
            float explosionRadius,
            float upwardsModifier = 0,
            ForceMode forceMode = ForceMode.Force)
        {
            Rigidbody rigidbody = gameObject.GetComponentFromRoot<Rigidbody>();

            ExplodeRigidbody(
                rigidbody,
                explosionPosition,
                explosionForce,
                explosionRadius,
                upwardsModifier,
                forceMode);
        }

        public static void ExplodeRigidbody(
            Rigidbody rigidbody,
            Vector3 explosionPosition,
            float explosionForce,
            float explosionRadius,
            float upwardsModifier = 0,
            ForceMode forceMode = ForceMode.Force)
        {
            if (!rigidbody)
            {
                return;
            }

            rigidbody.AddExplosionForce(
                explosionForce,
                explosionPosition,
                explosionRadius,
                upwardsModifier,
                forceMode);
        }
    }
}