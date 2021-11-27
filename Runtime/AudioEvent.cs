using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu]
    public class AudioEvent : GameEvent<AudioEventListener>
    {
        protected override void Invoke()
        {
            for (int i = (EventListeners.Count - 1); i != 0; i--)
            {
                EventListeners[i].OnEventRaised();
            }
        }

        public override void Register(AudioEventListener listener)
        {
            if (!EventListeners.Contains(listener))
                EventListeners.Add(listener);
        }

        public override void Unregister(AudioEventListener listener)
        {
            if (EventListeners.Contains(listener))
                EventListeners.Remove(listener);
        }
    }
}
