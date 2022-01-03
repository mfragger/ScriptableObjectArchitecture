using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider))]
    public class TagsOnTriggerStayListener : TagsEventFunctionsListener
    {
        private void OnTriggerStay(Collider other)
        {
            Invoke(other);
        }
    }
}
