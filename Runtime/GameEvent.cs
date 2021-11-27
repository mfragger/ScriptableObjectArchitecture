using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public abstract class GameEvent : ScriptableObject
    {
        protected abstract void Invoke();
    }

    public abstract class GameEvent<T> : GameEvent where T : GameEventListener
    {
        protected List<T> EventListeners = new List<T>();
        public abstract void Register(T gameEventListener);
        public abstract void Unregister(T gameEventListener);
    }
}
