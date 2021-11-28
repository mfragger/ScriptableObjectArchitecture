using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField]
        protected GameEvent GameEvent;

        [SerializeField]
        protected UnityEvent Response;

        private void Awake()
        {
            this.enabled = !(GameEvent == null);
        }
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
