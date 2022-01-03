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
        protected UnityEvent<T0> Response;

        protected T0 args0;
    }

    public abstract class EventListener<T0, T1> : MonoBehaviour
    {
        [SerializeField]
        protected UnityEvent<T0, T1> Response;

        protected T0 args0;
        protected T1 args1;
    }

    public abstract class EventListener<T0, T1, T2> : MonoBehaviour
    {
        [SerializeField]
        protected UnityEvent<T0, T1, T2> Response;

        protected T0 args0;
        protected T1 args1;
        protected T2 args2;
    }

    public abstract class EventListener<T0, T1, T2, T3> : MonoBehaviour
    {
        [SerializeField]
        protected UnityEvent<T0, T1, T2, T3> Response;

        protected T0 args0;
        protected T1 args1;
        protected T2 args2;
        protected T3 args3;
    }
}