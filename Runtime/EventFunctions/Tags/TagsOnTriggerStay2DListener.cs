using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider2D))]
    public class TagsOnTriggerStay2DListener : TagsEventFunctionsListener
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            Invoke(other);
        }
    }
}
