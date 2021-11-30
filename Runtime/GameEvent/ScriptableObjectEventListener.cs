using UnityEngine;
using UnityEngine.Events;

public abstract class ScriptableObjectEventListener : MonoBehaviour
{
    [SerializeField]
    protected UnityEvent Response;
}