using UnityEngine;
using UnityEngine.Events;
namespace ScriptableObjectArchitecture
{
    public abstract class ScriptableObjectEventListener : MonoBehaviour
    {
        [SerializeField]
        protected UnityEvent Response;
    }
}