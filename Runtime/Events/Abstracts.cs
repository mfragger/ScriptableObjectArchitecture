using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    public abstract class EventListener : MonoBehaviour
    {
        [SerializeField]
        protected UnityEvent Response;
    }

    public abstract class EventListener<T0> : MonoBehaviour
    {
        [SerializeField]
        public List<Responses<T0>> Responses;
    }

    [Serializable]
    public class Responses<T0>
    {
        public UnityEvent<T0> Response;

        public T0 args0;
    }

    public abstract class EventListener<T0, T1> : MonoBehaviour
    {
        [SerializeField]
        public List<Responses<T0, T1>> Responses;
    }

    [Serializable]
    public class Responses<T0, T1>
    {
        public UnityEvent<T0, T1> Response;

        public T0 args0;
        public T1 args1;
    }

    public abstract class EventListener<T0, T1, T2> : MonoBehaviour
    {
        [SerializeField]
        public List<Responses<T0, T1, T2>> Responses;
    }

    [Serializable]
    public class Responses<T0, T1, T2>
    {
        public UnityEvent<T0, T1, T2> Response;

        public T0 args0;
        public T1 args1;
        public T2 args2;
    }

    public abstract class EventListener<T0, T1, T2, T3> : MonoBehaviour
    {
        [SerializeField]
        public List<Responses<T0, T1, T2, T3>> Responses;
    }

    [Serializable]
    public class Responses<T0, T1, T2, T3>
    {
        public UnityEvent<T0, T1, T2, T3> Response;

        public T0 args0;
        public T1 args1;
        public T2 args2;
        public T3 args3;
    }

    public abstract class GameEvent<T0> : ScriptableObject
    {
        protected List<GameEventListener<T0>> EventListeners = new List<GameEventListener<T0>>();

        public void Register(GameEventListener<T0> gameEventListener)
        {
            if (!EventListeners.Contains(gameEventListener))
                EventListeners.Add(gameEventListener);
        }

        public void Unregister(GameEventListener<T0> gameEventListener)
        {
            if (EventListeners.Contains(gameEventListener))
                EventListeners.Remove(gameEventListener);
        }

        public void InvokeEvent()
        {
            for (int i = (EventListeners.Count - 1); i >= 0; i--)
            {
                EventListeners[i].OnEventRaised();
            }
        }
    }

    public abstract class GameEventListener<T0> : EventListener<T0>
    {
        [SerializeField]
        protected GameEvent<T0> GameEvent;
        private void OnEnable()
        {
            GameEvent.Register(this);
        }

        private void OnDisable()
        {
            GameEvent.Unregister(this);
        }

        public void OnEventRaised()
        {
            for (int i = 0; i < Responses.Count; i++)
            {
                Responses[i].Response.Invoke(Responses[i].args0);
            }
        }
    }

    public abstract class GameEvent<T0, T1> : ScriptableObject
    {
        protected List<GameEventListener<T0, T1>> EventListeners = new List<GameEventListener<T0, T1>>();

        public void Register(GameEventListener<T0, T1> gameEventListener)
        {
            if (!EventListeners.Contains(gameEventListener))
                EventListeners.Add(gameEventListener);
        }

        public void Unregister(GameEventListener<T0, T1> gameEventListener)
        {
            if (EventListeners.Contains(gameEventListener))
                EventListeners.Remove(gameEventListener);
        }

        public void InvokeEvent()
        {
            for (int i = (EventListeners.Count - 1); i >= 0; i--)
            {
                EventListeners[i].OnEventRaised();
            }
        }
    }

    public abstract class GameEventListener<T0, T1> : EventListener<T0, T1>
    {
        [SerializeField]
        protected GameEvent<T0, T1> GameEvent;
        private void OnEnable()
        {
            GameEvent.Register(this);
        }

        private void OnDisable()
        {
            GameEvent.Unregister(this);
        }

        public void OnEventRaised()
        {
            for (int i = 0; i < Responses.Count; i++)
            {
                Responses[i].Response.Invoke(Responses[i].args0, Responses[i].args1);
            }
        }
    }

    public abstract class GameEvent<T0, T1, T2> : ScriptableObject
    {
        protected List<GameEventListener<T0, T1, T2>> EventListeners = new List<GameEventListener<T0, T1, T2>>();

        public void Register(GameEventListener<T0, T1, T2> gameEventListener)
        {
            if (!EventListeners.Contains(gameEventListener))
                EventListeners.Add(gameEventListener);
        }

        public void Unregister(GameEventListener<T0, T1, T2> gameEventListener)
        {
            if (EventListeners.Contains(gameEventListener))
                EventListeners.Remove(gameEventListener);
        }

        public void InvokeEvent()
        {
            for (int i = (EventListeners.Count - 1); i >= 0; i--)
            {
                EventListeners[i].OnEventRaised();
            }
        }
    }

    public abstract class GameEventListener<T0, T1, T2> : EventListener<T0, T1, T2>
    {
        [SerializeField]
        protected GameEvent<T0, T1, T2> GameEvent;
        private void OnEnable()
        {
            GameEvent.Register(this);
        }

        private void OnDisable()
        {
            GameEvent.Unregister(this);
        }

        public void OnEventRaised()
        {
            for (int i = 0; i < Responses.Count; i++)
            {
                Responses[i].Response.Invoke(Responses[i].args0, Responses[i].args1, Responses[i].args2);
            }
        }
    }
    public abstract class GameEvent<T0, T1, T2, T3> : ScriptableObject
    {
        protected List<GameEventListener<T0, T1, T2, T3>> EventListeners = new List<GameEventListener<T0, T1, T2, T3>>();

        public void Register(GameEventListener<T0, T1, T2, T3> gameEventListener)
        {
            if (!EventListeners.Contains(gameEventListener))
                EventListeners.Add(gameEventListener);
        }

        public void Unregister(GameEventListener<T0, T1, T2, T3> gameEventListener)
        {
            if (EventListeners.Contains(gameEventListener))
                EventListeners.Remove(gameEventListener);
        }

        public void InvokeEvent()
        {
            for (int i = (EventListeners.Count - 1); i >= 0; i--)
            {
                EventListeners[i].OnEventRaised();
            }
        }
    }

    public abstract class GameEventListener<T0, T1, T2, T3> : EventListener<T0, T1, T2, T3>
    {
        [SerializeField]
        protected GameEvent<T0, T1, T2, T3> GameEvent;
        private void OnEnable()
        {
            GameEvent.Register(this);
        }

        private void OnDisable()
        {
            GameEvent.Unregister(this);
        }

        public void OnEventRaised()
        {
            for (int i = 0; i < Responses.Count; i++)
            {
                Responses[i].Response.Invoke(Responses[i].args0, Responses[i].args1, Responses[i].args2, Responses[i].args3);
            }
        }
    }
}