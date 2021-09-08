using System;

namespace niscolas.UnityUtils.Core
{
    public static class ComparisonUtility
    {
        public static bool Compare<T>(T x, ComparisonOperator comparisonOperator, T y) where T : IComparable
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.EqualTo:
                    return x.CompareTo(y) == 0;

                case ComparisonOperator.NotEqual:
                    return x.CompareTo(y) != 0;

                case ComparisonOperator.GreaterThan:
                    return x.CompareTo(y) > 0;

                case ComparisonOperator.GreaterThanOrEqualTo:
                    return x.CompareTo(y) >= 0;

                case ComparisonOperator.LessThan:
                    return x.CompareTo(y) < 0;

                case ComparisonOperator.LessThanOrEqualTo:
                    return x.CompareTo(y) <= 0;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
