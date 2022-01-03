using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider2D))]
    public class TagsOnTriggerEnter2DListener : TagsEventFunctionsListener
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Invoke(other);
        }
    }
}
