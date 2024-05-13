using System.Collections.Generic;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> SkipWhileLast<T>
            (this IEnumerable<T> self,
            Func<T, bool> predicate)
        {
            var buffer = new List<T>();
            var yieldStarted = false;

            foreach (var item in self)
            {
                if (predicate(item))
                {
                    buffer.Add(item);
                    yieldStarted = true;
                }
                else
                {
                    if (yieldStarted)
                    {
                        foreach (var bufferedItem in buffer)
                        {
                            yield return bufferedItem;
                        }

                        buffer.Clear();
                    }

                    yield return item;
                }
            }
        }

        public static IEnumerable<T> GetRandomRange<T>(this IEnumerable<T> self, int count)
        {
            var buffer = new List<T>(self);

            return buffer
                .Shuffle()
                .Take(count);
        }

        public static IOrderedEnumerable<T> Shuffle<T>
            (this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || collection.Count() == 0;
        }

        public static IEnumerable<TSource> TryConcat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null)
            {
                return second;
            }
            else if (second == null)
            {
                return first;
            }
            else
            {
                return first.Concat(second);
            }
        }

        public static bool TryForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            if (self == null)
            {
                return false;
            }
            else
            {
                foreach (var item in self)
                {
                    action(item);
                }

                return true;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self)
            {
                action(item);
            }
        }

        public static Queue<T> ToQueue<T>(this IEnumerable<T> self)
        {
            return new Queue<T>(self);
        }

        public static T Next<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool flag = false;

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (flag) return enumerator.Current;

                    if (predicate(enumerator.Current))
                    {
                        flag = true;
                    }
                }
            }
            return default;
        }

        public static T Previous<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            T previous = default;

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                    {
                        return previous;
                    }

                    previous = enumerator.Current;
                }
            }
            return previous;
        }

        public static bool ExistNext<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool flag = false;

            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (flag) return true;

                if (predicate(enumerator.Current))
                {
                    flag = true;
                }
            }
            return false;
        }

        public static bool ExistPrevious<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
