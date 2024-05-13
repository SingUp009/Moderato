using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public static class AwaitableEnumerator
{
    public static UniTask WhenAll(this IEnumerable<UniTask> tasks)
    {
        return UniTask.WhenAll(tasks);
    }

    public static UniTask<T[]> WhenAll<T>(this IEnumerable<UniTask<T>> tasks)
    {
        return UniTask.WhenAll(tasks);
    }
}
