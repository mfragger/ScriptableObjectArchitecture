using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [DefaultExecutionOrder(2)]
    [CreateAssetMenu(menuName = "SO Architecture/Filter/Filter", fileName = "New Filter")]
    public class FilterObject : ScriptableObject
    {
        [SerializeField]
        private List<GameObjectTag> any;

        [SerializeField]
        private List<GameObjectTag> all;

        [SerializeField]
        private List<GameObjectTag> none;

        public List<GameObject> RunFilter()
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
            return resultHash.ToList();
        }

        public Task<List<GameObject>> RunFilterAsync()
        {
            return Task.Run(() =>
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
                return resultHash.ToList();
            });
        }
    }
}
