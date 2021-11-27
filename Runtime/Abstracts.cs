using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    public abstract class Variable : ScriptableObject { }
    public abstract class ConstantVariable<T> : Variable
    {
        public abstract T GetValue();
    }
    public abstract class Collection : ScriptableObject { }
    public abstract class ConstantCollection<T> : Collection
    {
        public abstract T GetValue(int i);
    }
    public abstract class GameEvent<T> : GameEvent where T : GameEventListener
    {
        protected List<T> EventListeners = new List<T>();
        public abstract void Register(T gameEventListener);
        public abstract void Unregister(T gameEventListener);
    }

    public abstract class GameEventListener : MonoBehaviour
    {
        protected abstract void OnEnable();
        protected abstract void OnDisable();

    }

    public abstract class GameEventListener<T> : GameEventListener where T : GameEvent
    {
        [SerializeField]
        protected T GameEvent;

        [SerializeField]
        protected UnityEvent Response;

        /// <summary>
        /// Don't call this on Awake
        /// </summary>
        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }

    public abstract class GameEvent : ScriptableObject
    {
        public abstract void InvokEvent();
    }

    public abstract class TagObject<T> : ScriptableObject
    {
        [HideInInspector]
        public List<T> TaggedObjects;

        public void Add(T Object)
        {
            TaggedObjects.Add(Object);
        }
        public void Remove(T Object)
        {
            TaggedObjects.Remove(Object);
        }
    }

    public abstract class TagMonoBehaviour<T> : MonoBehaviour
    {
        public List<TagObject<T>> Tags;

        /// <summary>
        /// when overrding call AddObject(T Object)
        /// </summary>
        protected abstract void OnEnable();

        protected void AddObject(T Object)
        {
            for (int i = 0; i < Tags.Count; i++)
            {
                Tags[i].Add(Object);
            }
        }

        /// <summary>
        /// when overrding call RemoveObject(T Object)
        /// </summary>
        protected abstract void OnDisable();

        protected void RemoveObject(T Object)
        {
            for (int i = 0; i < Tags.Count; i++)
            {
                Tags[i].Add(Object);
            }
        }
    }
}
