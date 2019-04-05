using System;
using System.Collections.Generic;

namespace Neural_Network.Extensions
{
    internal static class Extensions
    {
        public static double NextDouble(this Random rnd, double minValue, double maxValue)
        {
            return rnd.NextDouble() * (maxValue - minValue) + minValue;
        }

        public static IEnumerable<T> Reverse<T>(this IList<T> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }
    }
}
