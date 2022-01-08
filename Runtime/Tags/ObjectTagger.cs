using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public abstract class ObjectTagger<T> : MonoBehaviour
    {
        public Tag<T>[] Tags;
        protected abstract void OnEnable();
        protected abstract void OnDisable();
    }
}
