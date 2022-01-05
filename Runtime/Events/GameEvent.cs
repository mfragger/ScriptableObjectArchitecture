using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Event/GameEvent Object", fileName = "New GameEvent Object", order = 41)]

    public class GameEvent : ScriptableObject
    {
        protected List<GameEventListener> EventListeners = new List<GameEventListener>();
        private HashSet<GameEventListener> Set = new HashSet<GameEventListener>();

        public void Register(GameEventListener gameEventListener)
        {
            if (!Set.Contains(gameEventListener))
            {
                Set.Add(gameEventListener);
                EventListeners.Add(gameEventListener);
            }
        }

        public void Unregister(GameEventListener gameEventListener)
        {
            if (Set.Contains(gameEventListener))
            {
                Set.Remove(gameEventListener);
                EventListeners.Remove(gameEventListener);
            }
        }

        public void InvokeEvent()
        {
            for (int i = (EventListeners.Count - 1); i >= 0; i--)
            {
                EventListeners[i].OnEventRaised();
            }
        }
    }
}
