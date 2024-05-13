using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Unity.Linq
{
    public static partial class GameObjectExtensions
    {
        public static IOrderedEnumerable<GameObject> OrderBy(this IEnumerable<GameObject> source, Func<GameObject, float> keySelector)
        {
            var ordered = source.OrderBy(keySelector);
            ordered.Select((gameObject, index) => (gameObject, index)).ForEach(x =>
            {
                x.gameObject.transform.SetSiblingIndex(x.index);
            });

            return ordered;
        }
    }
}
