using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [Serializable]
    public class SerializedHashSet<T> : ISet<T>, IReadOnlyCollection<T>, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<T> list = new List<T>();

        private HashSet<T> set = new HashSet<T>();

        public int Count => set.Count();

        public bool IsReadOnly => false;

        public void OnBeforeSerialize()
        {
            list.Clear();
            foreach (var item in set)
            {
                list.Add(item);
            }
        }

        public void OnAfterDeserialize()
        {
            set = new HashSet<T>();
            for (int i = 0; i < list.Count; i++)
            {
                set.Add(list[i]);
            }
        }

        public bool Add(T item)
        {
            if (set.Add(item))
            {
                list.Add(item);
                return true;
            }
            return false;
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            set.ExceptWith(other);
            list = set.ToList();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            set.Intersect(other);
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

        public bool SetEquals(IEnumerable<T> other)
        {
            return set.SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            set.SymmetricExceptWith(other);
            list = set.ToList();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            set.UnionWith(other);
            list = set.ToList();
        }

        void ICollection<T>.Add(T item)
        {
            set.Add(item);
            list = set.ToList();
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
            list = set.ToList();
        }

        public bool Remove(T item)
        {
            if (set.Remove(item))
            {
                list.Remove(item);
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return set.GetEnumerator();
        }
    }
}