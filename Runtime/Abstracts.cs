using JetBrains.Annotations;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    //Variables
    public abstract class Variable<T> : ScriptableObject
    {
        public T Value;

#if UNITY_EDITOR
        public bool ResetAfterPlayMode;

        [NonSerialized]
        public Variable<T> CopyObject;

        public void ReInitCache(PlayModeStateChange playModeStateChange)
        {
            if (PlayModeStateChange.ExitingPlayMode == playModeStateChange)
            {
                if (CopyObject != null)
                {
                    Value = CopyObject.Value;
                    DestroyImmediate(CopyObject);
                    CopyObject = null;
                }
                EditorApplication.playModeStateChanged -= ReInitCache;
            }
        }
#endif

    }
    public abstract class ConstantVariable<T> : ScriptableObject
    {
        [SerializeField]
        private T value;

        public T Value
        {
            get
            {
                T copy = value;
                return copy;
            }
        }
    }

    //Collections
    public abstract class Collection<T> : ScriptableObject
    {
        public T[] Values;

#if UNITY_EDITOR
        public bool ResetAfterPlayMode;

        [NonSerialized]
        public Collection<T> CopyObject;

        public void ReInitCache(PlayModeStateChange playModeStateChange)
        {
            if (PlayModeStateChange.ExitingPlayMode == playModeStateChange)
            {
                Values = CopyObject.Values;
                DestroyImmediate(CopyObject);
                CopyObject = null;
                EditorApplication.playModeStateChanged -= ReInitCache;
            }
        }
#endif

    }
    public abstract class ConstantCollection<T> : ScriptableObject
    {
        [SerializeField]
        private new T[] Values;
        public T GetValue(int i)
        {
            return Values[i];
        }
        public T[] GetValueRange(int fromIndexInclusive, int toIndexInclusive)
        {
            return Values[fromIndexInclusive..(toIndexInclusive - 1)];
        }
        public T[] GetCollection()
        {
            return Values.ToArray();
        }
        public T Find(T item)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                if (Values[i].Equals(item))
                    return Values[i];
            }
            return default;
        }
        public int GetLength()
        {
            return Values.Length;
        }
    }
}
