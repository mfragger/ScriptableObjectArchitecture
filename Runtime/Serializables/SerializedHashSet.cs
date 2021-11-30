using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [Serializable]
    public class SerializedHashSet<T> : ISet<T>, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<T> list = new List<T>();

        private HashSet<T> set = new HashSet<T>();

        //[SerializeField]
        //private bool collision;

        public void OnBeforeSerialize() { }
        public void OnAfterDeserialize()
        {
            set.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if (item != null && !Contains(item))
                {
                    set.Add(item);
                }
                else
                {
                    //collision = true;
                }
            }
        }

        public int Count => set.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        public bool Add(T item)
        {
            if (set.Add(item))
            {
                list.Add(item);
            }
            return true;
        }

        public void Clear()
        {
            set.Clear();
            list.Clear();
        }

        public bool Contains(T item)
        {
            return set.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            set.CopyTo(array, arrayIndex);
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            set.ExceptWith(other);
            list.Clear();
            list = set.ToList();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return set.GetEnumerator();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            set.IntersectWith(other);
            list.Clear();
            list = set.ToList();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return set.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return set.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return set.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return set.IsSupersetOf(other);
        }


        public bool Overlaps(IEnumerable<T> other)
        {
            return set.Overlaps(other);
        }

        public bool Remove(T item)
        {
            return set.Remove(item);
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return set.SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            set.SymmetricExceptWith(other);
        }

        public void UnionWith(IEnumerable<T> other)
        {
            set.UnionWith(other);
        }

        void ICollection<T>.Add(T item)
        {
            set.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return set.GetEnumerator();
        }
    }
}