using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public abstract class ConstCollection<T> : ScriptableObject
    {
        [SerializeField]
        private T[] values;

#if UNITY_EDITOR
        [SerializeField]
        private bool resetAfterPlayMode;

        [SerializeField]
        [HideInInspector]
        private T[] copyValues;
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
            if (resetAfterPlayMode)
            {
                copyValues = values;
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
        }

        private void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (resetAfterPlayMode && obj == PlayModeStateChange.EnteredEditMode)
            {
                values = copyValues;
                EditorApplication.playModeStateChanged -= EditorApplication_playModeStateChanged;
            }
        }
#endif
        public T GetValue(int i)
        {
            return values[i];
        }
        public T[] GetValueRange(int fromIndexInclusive, int toIndexInclusive)
        {
#if UNITY_2021_2_OR_NEWER
            return values[fromIndexInclusive..(toIndexInclusive - 1)];
#else
            List<T> values = new List<T>();
            for (int i = fromIndexInclusive; i <= toIndexInclusive; i++)
            {
                values.Add(Values[i]);
            }
            return values.ToArray();
#endif
        }

        public T[] GetCollection => values;

        public T Find(T item)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Equals(item))
                {
                    return values[i];
                }
            }
            return default;
        }

        public int GetLength()
        {
            return values.Length;
        }
    }
}
