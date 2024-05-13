using System.Collections.Generic;
using System;

namespace ListExtetions
{
    public static class ListExtension
    {
        public static T LoopElementAt<T>(this IList<T> list, int index)
        {
            if (list.Count == 0) throw new ArgumentException("要素数が0のためアクセスできません");

            index %= list.Count;

            if (index < 0)
            {
                index += list.Count;
            }

            return list[index];
        }

        public static IList<T> Move<T>(this IList<T> list, int oldIndex, int newIndex)
        {
            if (list.Count == 0) throw new ArgumentException("要素数が0のためアクセスできません");

            if (oldIndex < 0 || list.Count <= oldIndex) throw new ArgumentOutOfRangeException("oldIndex");
            if (newIndex < 0 || list.Count <= newIndex) throw new ArgumentOutOfRangeException("newIndex");

            var item = list[oldIndex];
            list.RemoveAt(oldIndex);
            list.Insert(newIndex, item);

            return list;
        }
    }

}
