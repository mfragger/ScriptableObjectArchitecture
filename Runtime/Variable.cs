using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    //Variables
    public abstract class Variable<T0, T1> : ScriptableObject, IResetValues, ICallback<Variable<T0, T1>.IValueChange> where T1 : Variable<T0, T1>
    {
        public interface IValueChange
        {
            void OnValueChanged(T1 variableObject, T0 newValue);
        }

        protected readonly List<IValueChange> onChangeCallbacks = new();

        public virtual T0 Value
        {
            get => value;
            set
            {
                this.value = value;
                for (int i = 0; i < onChangeCallbacks.Count; i++)
                {
                    onChangeCallbacks[i].OnValueChanged((T1)this, value);
                }
            }
        }

        [SerializeField]
        protected T0 value;

        [SerializeField]
        private bool includeToResetList;

        [SerializeField]
        [HideInInspector]
        private T0 copyValue;

#if UNITY_EDITOR
        [SerializeField]
        private bool resetAfterPlayMode;
#endif

        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            ResetAfterPlaymode();
#endif
            if (includeToResetList)
            {
                MakeCopy();
                ScriptableObjectArchitectureUtility.Add(this);
            }
        }

        protected virtual void OnDisable()
        {
            ScriptableObjectArchitectureUtility.Remove(this);
        }

#if UNITY_EDITOR
        private void ResetAfterPlaymode()
        {
            if (resetAfterPlayMode)
            {
                MakeCopy();
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
        }
#endif

#if UNITY_EDITOR
        private void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (resetAfterPlayMode && obj == PlayModeStateChange.EnteredEditMode)
            {
                ResetValues();
                EditorApplication.playModeStateChanged -= EditorApplication_playModeStateChanged;
            }
        }
#endif
        public void SetCallback(IValueChange @interface)
        {
            onChangeCallbacks.Add(@interface);
        }

        public void UnsetCallback(IValueChange @interface)
        {
            onChangeCallbacks.Remove(@interface);
        }

        private void MakeCopy()
        {
            copyValue = Value;
        }

        public void ResetValues()
        {
            Value = copyValue;
        }
    }
}
