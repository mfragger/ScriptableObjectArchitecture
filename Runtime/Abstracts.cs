using System;
using System.Collections.Generic;
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

        public T Value => value;
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
        private T[] Values;
        public T GetValue(int i)
        {
            return Values[i];
        }
        public T[] GetValueRange(int fromIndexInclusive, int toIndexInclusive)
        {
#if UNITY_2021_2_OR_NEWER
            return Values[fromIndexInclusive..(toIndexInclusive - 1)];
#else
            List<T> values = new List<T>();
            for (int i = fromIndexInclusive; i <= toIndexInclusive; i++)
            {
                values.Add(Values[i]);
            }
            return values.ToArray();
#endif
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
