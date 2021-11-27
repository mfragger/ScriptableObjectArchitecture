using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu]
    public class GameObjectEvent : GameEvent<GameObjectEventListener>
    {
        public override void Register(GameObjectEventListener gameEventListener)
        {
            if (!EventListeners.Contains(gameEventListener))
                EventListeners.Add(gameEventListener);
        }

        public override void Unregister(GameObjectEventListener gameEventListener)
        {
            if (EventListeners.Contains(gameEventListener))
                EventListeners.Remove(gameEventListener);
        }

        public override void InvokEvent()
        {
            for (int i = (EventListeners.Count - 1); i >= 0; i--)
            {
                EventListeners[i].OnEventRaised();
            }
        }
    }
}
