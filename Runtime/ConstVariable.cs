using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public abstract class ConstVariable<T> : ScriptableObject
    {
        [SerializeField]
        private T value;

        public T Value => value;

#if UNITY_EDITOR
        [SerializeField]
        private bool resetAfterPlayMode;

        [SerializeField]
        [HideInInspector]
        private T copyValue;
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
                copyValue = Value;
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
        }

        private void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (resetAfterPlayMode && obj == PlayModeStateChange.EnteredEditMode)
            {
                value = copyValue;
                EditorApplication.playModeStateChanged -= EditorApplication_playModeStateChanged;
            }
        }
#endif
    }
}
