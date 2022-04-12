using UnityEngine;

namespace ScriptableObjectArchitecture.InputSystem
{
    public abstract class Input<T> : ScriptableObject where T : class
    {
        protected T inputMap;
        protected virtual void OnEnable()
        {
            EnableAllPlayerInput();
        }

        protected virtual void OnDisable()
        {
            DisableAllPlayerInput();
        }

        public abstract void EnableAllPlayerInput();
        public abstract void DisableAllPlayerInput();
    }
}