using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    //Collections
    public abstract class RefCollection<T0, T1> : ScriptableObject, IResetValues, ICallback<RefCollection<T0, T1>.IValueChangeOnIndex>, ICallback<RefCollection<T0, T1>.ICollectionChange> where T1 : RefCollection<T0, T1>
    {
        public interface IValueChangeOnIndex
        {
            void OnChanged(T1 collectionObject, int index, T0 newValue);
        }

        public interface ICollectionChange
        {
            void OnChanged(T1 collectionObject, T0[] newCollection);
        }

        private readonly List<IValueChangeOnIndex> OnValueChangeOnIndexCallback = new();
        private readonly List<ICollectionChange> OnCollectionChangeCallback = new();

        [SerializeField]
        private T0[] values;
        public int Length => values.Length;
        public long LongLength => values.LongLength;

        [SerializeField]
        private bool includeToResetList;

        [SerializeField]
        [HideInInspector]
        private T0[] copyValues;

#if UNITY_EDITOR
        [SerializeField]
        private bool resetAfterPlayMode;
#endif

        /// <summary>
        /// Gets a referrence to the array raw. <br />
        /// Any changes to this won't invoke the interfaces.
        /// </summary>
        public T0[] GetCollection => values;

        public T0 GetValue(int index) => values[index];

        public T0[] GetCopy() => values.ToArray();

        public void SetValue(int index, T0 value)
        {
            SetNoCallback(index, value);
            for (int i = 0; i < OnValueChangeOnIndexCallback.Count; i++)
            {
                OnValueChangeOnIndexCallback[i].OnChanged((T1)this, index, value);
            }
        }

        public void SetNoCallback(int index, T0 value)
        {
            values[index] = value;
        }

        public void Set(T0[] values)
        {
            SetNoCallback(values);
            for (int i = 0; i < OnCollectionChangeCallback.Count; i++)
            {
                OnCollectionChangeCallback[i].OnChanged((T1)this, values);
            }
        }

        public void SetNoCallback(T0[] values)
        {
            this.values = values;
        }

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

#if UNITY_EDITOR
        private void ResetAfterPlaymode()
        {
            if (resetAfterPlayMode)
            {
                MakeCopy();
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
        }

        private void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (resetAfterPlayMode && obj == PlayModeStateChange.EnteredEditMode)
            {
                ResetValues();
                EditorApplication.playModeStateChanged -= EditorApplication_playModeStateChanged;
            }
        }
#endif
        public void SetCallback(IValueChangeOnIndex @interface)
        {
            OnValueChangeOnIndexCallback.Add(@interface);
        }

        public void UnsetCallback(IValueChangeOnIndex @interface)
        {
            OnValueChangeOnIndexCallback.Remove(@interface);
        }

        public void SetCallback(ICollectionChange @interface)
        {
            OnCollectionChangeCallback.Add(@interface);
        }

        public void UnsetCallback(ICollectionChange @interface)
        {
            OnCollectionChangeCallback.Remove(@interface);
        }

        private void MakeCopy()
        {
            values.CopyTo(copyValues, 0);
        }

        public void ResetValues()
        {
            copyValues.CopyTo(values, 0);
        }
    }
}
