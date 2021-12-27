using UnityEngine;
using UnityEngine.Animations;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class IConstraintExtensions
    {
        public static int AddSourceAndSetActive(
            this IConstraint constraint,
            Transform sourceTransform,
            float weight = 1f,
            bool activeState = true)
        {
            int sourceIndex = constraint.AddSource(
                new ConstraintSource
                {
                    sourceTransform = sourceTransform,
                    weight = weight
                });
            constraint.constraintActive = activeState;

            return sourceIndex;
        }
    }
}