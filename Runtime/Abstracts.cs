using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    //Variables
    public abstract class Variable<T0, T1> : ScriptableObject, IResetValues where T1 : Variable<T0, T1>
    {
        public interface IValueChange
        {
            void OnValueChanged(T1 variableObject, T0 newValue);
        }

        protected readonly List<IValueChange> OnChangeCallbacks = new();

        public virtual T0 Value
        {
            get => value;
            set
            {
                this.value = value;
                for (int i = 0; i < OnChangeCallbacks.Count; i++)
                {
                    OnChangeCallbacks[i].OnValueChanged((T1)this, value);
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
        private bool ResetAfterPlayMode;
#endif

        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            ResetAfterPlaymode();
#endif
            if (includeToResetList)
            {
                MakeCopy();
                SOArchitectureUtility.Add(this);
            }
        }

        private void OnDisable()
        {
            SOArchitectureUtility.Remove(this);
        }

#if UNITY_EDITOR
        private void ResetAfterPlaymode()
        {
            if (ResetAfterPlayMode)
            {
                MakeCopy();
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
        }
#endif


#if UNITY_EDITOR
        private void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (ResetAfterPlayMode && obj == PlayModeStateChange.EnteredEditMode)
            {
                ResetValues();
                EditorApplication.playModeStateChanged -= EditorApplication_playModeStateChanged;
            }
        }
#endif

        public void AddToCallback(IValueChange changeValue)
        {
            OnChangeCallbacks.Add(changeValue);
        }

        public void RemoveFromCallback(IValueChange changeValue)
        {
            OnChangeCallbacks.Remove(changeValue);
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
    public abstract class ConstVariable<T> : ScriptableObject
    {
        [SerializeField]
        private T value;

        public T Value => value;

#if UNITY_EDITOR
        [SerializeField]
        private bool ResetAfterPlayMode;

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
    public abstract class RefCollection<T0, T1> : ScriptableObject, IResetValues where T1 : RefCollection<T0, T1>
    {
        public interface IValueChangeOnIndex
        {
            void OnChanged(T1 collectionObject, int index, T0 newValue);
        }

        public interface ICollectionChnage
        {
            void OnChanged(T1 collectionObject, T0[] newCollection);
        }

        private readonly List<IValueChangeOnIndex> OnValueChangeOnIndexCallback = new();
        private readonly List<ICollectionChnage> OnCollectionChangeCallback = new();

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
        private bool ResetAfterPlayMode;
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
                SOArchitectureUtility.Add(this);
            }
        }

#if UNITY_EDITOR
        private void ResetAfterPlaymode()
        {
            if (ResetAfterPlayMode)
            {
                MakeCopy();
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
        }

        private void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (ResetAfterPlayMode && obj == PlayModeStateChange.EnteredEditMode)
            {
                ResetValues();
                EditorApplication.playModeStateChanged -= EditorApplication_playModeStateChanged;
            }
        }
#endif

        public void AddToCallback(IValueChangeOnIndex changeValue)
        {
            OnValueChangeOnIndexCallback.Add(changeValue);
        }

        public void AddToCallback(ICollectionChnage changeValue)
        {
            OnCollectionChangeCallback.Add(changeValue);
        }

        public void RemoveFromCallback(IValueChangeOnIndex changeValue)
        {
            OnValueChangeOnIndexCallback.Remove(changeValue);
        }

        public void RemoveFromCallback(ICollectionChnage changeValue)
        {
            OnCollectionChangeCallback.Add(changeValue);
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

    public abstract class ConstCollection<T> : ScriptableObject
    {
        [SerializeField]
        private T[] values;

#if UNITY_EDITOR
        [SerializeField]
        private bool ResetAfterPlayMode;

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
            if (ResetAfterPlayMode)
            {
                copyValues = values;
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
        }

        private void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (ResetAfterPlayMode && obj == PlayModeStateChange.EnteredEditMode)
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
