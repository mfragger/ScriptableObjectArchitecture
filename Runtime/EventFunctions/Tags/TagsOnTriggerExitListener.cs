using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider))]
    public class TagsOnTriggerExitListener : TagsEventFunctionsListener
    {
        private void OnTriggerExit(Collider other)
        {
            Invoke(other);

        }
    }
}
