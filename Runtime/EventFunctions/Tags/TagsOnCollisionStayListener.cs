using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider))]
    public class TagsOnCollisionStayListener : TagsEventFunctionsListener
    {
        private void OnCollisionStay(Collision other)
        {
            Invoke(other);
        }
    }
}
