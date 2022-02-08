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
        [SerializeField]
        private bool ResetAfterPlayMode;

        [HideInInspector]
        public T copyValue;
#endif
        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            ResetAfterPlaymode();
#endif
        }

#if UNITY_EDITOR
        private void ResetAfterPlaymode()
        {
            if (ResetAfterPlayMode)
            {
                copyValue = Value;
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
        }

        private void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (ResetAfterPlayMode && obj == PlayModeStateChange.EnteredEditMode)
            {
                Value = copyValue;
                EditorApplication.playModeStateChanged -= EditorApplication_playModeStateChanged;
            }
        }
#endif

    }
    public abstract class ConstantVariable<T> : ScriptableObject
    {
        [SerializeField]
        private T value;

        public T Value => value;

#if UNITY_EDITOR
        [SerializeField]
        private bool ResetAfterPlayMode;

        [HideInInspector]
        public T copyValue;
#endif
        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            ResetAfterPlaymode();
#endif
        }

#if UNITY_EDITOR
        private void ResetAfterPlaymode()
        {
            if (ResetAfterPlayMode)
            {
                copyValue = Value;
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
        }

        private void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (ResetAfterPlayMode && obj == PlayModeStateChange.EnteredEditMode)
            {
                value = copyValue;
                EditorApplication.playModeStateChanged -= EditorApplication_playModeStateChanged;
            }
        }
#endif
    }

    //Collections
    public abstract class Collection<T> : ScriptableObject
    {
        public T[] Values;

#if UNITY_EDITOR
        [SerializeField]
        private bool ResetAfterPlayMode;

        [HideInInspector]
        public T[] copyValues;
#endif
        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            ResetAfterPlaymode();
#endif
        }

#if UNITY_EDITOR
        private void ResetAfterPlaymode()
        {
            if (ResetAfterPlayMode)
            {
                copyValues = Values;
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
        }

        private void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (ResetAfterPlayMode && obj == PlayModeStateChange.EnteredEditMode)
            {
                Values = copyValues;
                EditorApplication.playModeStateChanged -= EditorApplication_playModeStateChanged;
            }
        }
#endif
    }

    public abstract class ConstantCollection<T> : ScriptableObject
    {
        [SerializeField]
        private T[] Values;

#if UNITY_EDITOR
        [SerializeField]
        private bool ResetAfterPlayMode;

        [HideInInspector]
        public T[] copyValues;
#endif
        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            ResetAfterPlaymode();
#endif
        }

#if UNITY_EDITOR
        private void ResetAfterPlaymode()
        {
            if (ResetAfterPlayMode)
            {
                copyValues = Values;
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
        }

        private void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (ResetAfterPlayMode && obj == PlayModeStateChange.EnteredEditMode)
            {
                Values = copyValues;
                EditorApplication.playModeStateChanged -= EditorApplication_playModeStateChanged;
            }
        }
#endif
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

        public T[] GetCollection => Values;
        public T Find(T item)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                if (Values[i].Equals(item))
                {
                    return Values[i];
                }
            }
            return default;
        }
        public int GetLength()
        {
            return Values.Length;
        }
    }
}
