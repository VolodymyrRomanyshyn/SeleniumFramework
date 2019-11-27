using System;
using System.Collections.Generic;

namespace Framework
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        public static T Random<T>(this IList<T> list)
        {
            return list.Count < 1 ? default(T) : list[new Random().Next(list.Count - 1)];
        }
    }
}
