using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    public abstract class GameEventListener : MonoBehaviour
    {
        [SerializeField]
        protected UnityEvent Response;

        protected abstract void OnEnable();
        protected abstract void OnDisable();

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }

    public abstract class GameEventListener<T> : GameEventListener where T : GameEvent
    {
        [SerializeField]
        protected T GameEvent;
    }
}