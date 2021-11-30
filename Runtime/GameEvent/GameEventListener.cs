using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    public class GameEventListener : ScriptableObjectEventListener
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
