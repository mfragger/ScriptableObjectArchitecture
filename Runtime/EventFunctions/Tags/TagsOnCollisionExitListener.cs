using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider))]
    public class TagsOnCollisionExitListener : TagsEventFunctionsListener
    {
        private void OnCollisionExit(Collision other)
        {
            Invoke(other);
        }
    }
}
