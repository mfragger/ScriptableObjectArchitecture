using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Event/GameEvent Object", fileName = "New GameEvent Object", order = 11)]

    public class GameEvent : ScriptableObject
    {
        protected List<GameEventListener> EventListeners = new List<GameEventListener>();

        public void Register(GameEventListener gameEventListener)
        {
            if (!EventListeners.Contains(gameEventListener))
                EventListeners.Add(gameEventListener);
        }

        public void Unregister(GameEventListener gameEventListener)
        {
            if (EventListeners.Contains(gameEventListener))
                EventListeners.Remove(gameEventListener);
        }

        public void InvokEvent()
        {
            for (int i = (EventListeners.Count - 1); i >= 0; i--)
            {
                EventListeners[i].OnEventRaised();
            }
        }
    }
}
