using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public static class Filter
    {
        internal static List<IRunFilter> filters = new();
        public static void RunFilters()
        {
            for (int i = 0; i < filters.Count; i++)
            {
                filters[i].RunFilter();
            }
        }
    }

    public interface IRunFilter
    {
        void RunFilter();
    }

    [DefaultExecutionOrder(2)]
    [CreateAssetMenu(menuName = "SO Architecture/Filter/Filter", fileName = "New Filter")]
    public class FilterObject : ScriptableObject, IRunFilter
    {
        [SerializeField]
        private List<GameObjectTag> any;

        [SerializeField]
        private List<GameObjectTag> all;

        [SerializeField]
        private List<GameObjectTag> none;

        [NonSerialized]
        public List<GameObject> ResultsList = new();

        private void OnEnable()
        {
            Filter.filters.Add(this);
        }
        private void OnDisable()
        {
            Filter.filters.Remove(this);
        }

        public void RunFilter()
        {
            var resultHash = new HashSet<GameObject>();
            if (any != null)
            {
                for (int i = 0; i < any.Count; i++)
                {
                    resultHash.UnionWith(any[i].TaggedObjects);
                }
            }
            if (all != null)
            {
                for (int i = 0; i < all.Count; i++)
                {
                    if (resultHash.Count == 0)
                    {
                        resultHash = all[i].TaggedObjects;
                    }
                    resultHash.IntersectWith(all[i].TaggedObjects);
                }
            }
            if (none != null)
            {
                for (int i = 0; i < none.Count; i++)
                {
                    resultHash.SymmetricExceptWith(none[i].TaggedObjects);
                }
            }
            ResultsList = resultHash.ToList();
        }
    }
}
