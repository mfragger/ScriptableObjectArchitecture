using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    public class GameEventListener : EventListener
    {
        [SerializeField]
        protected GameEvent GameEvent;
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
            Response.Invoke();
        }
    }
}
