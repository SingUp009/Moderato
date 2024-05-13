using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace UniRx
{
    public static class UniRxExtensions
    {
        public static void ForEach<T>(this ReactiveCollection<T> source, System.Action<T> action)
        {
            int count = source.Count;
            for (int i = 0; i < count; i++)
            {
                action(source[i]);
            }
        }
    }

    public static class ObservableSceneEvent
    {
        public static IObservable<(Scene current, Scene next)> ActiveSceneChangedAsObservable()
        {
            return Observable.FromEvent<UnityAction<Scene, Scene>, (Scene current, Scene next)>(
                h => (current, next) => h((current, next)),
                h => SceneManager.activeSceneChanged += h,
                h => SceneManager.activeSceneChanged -= h);
        }

        public static IObservable<Tuple<Scene, LoadSceneMode>> SceneLoadedAsObservable()
        {
            return Observable.FromEvent<UnityAction<Scene, LoadSceneMode>, Tuple<Scene, LoadSceneMode>>(
                h => (x, y) => h(Tuple.Create(x, y)),
                h => SceneManager.sceneLoaded += h,
                h => SceneManager.sceneLoaded -= h);
        }

        public static IObservable<Scene> SceneUnloadedAsObservable()
        {
            return Observable.FromEvent<UnityAction<Scene>, Scene>(
                h => h.Invoke,
                h => SceneManager.sceneUnloaded += h,
                h => SceneManager.sceneUnloaded -= h);
        }
    }
}
