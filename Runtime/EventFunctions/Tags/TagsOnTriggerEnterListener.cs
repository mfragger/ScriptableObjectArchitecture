using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider))]
    public class TagsOnTriggerEnterListener : TagsEventFunctionsListener
    {
        private void OnTriggerEnter(Collider other)
        {
            Invoke(other);
        }
    }
}
