using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider2D))]
    public class TagsOnTriggerExit2DListener : TagsEventFunctionsListener
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            Invoke(other);
        }
    }
}
