using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider))]
    public class TagsOnCollisionEnterListener : TagsEventFunctionsListener
    {
        private void OnCollisionEnter(Collision other)
        {
            Invoke(other);
        }
    }
}
