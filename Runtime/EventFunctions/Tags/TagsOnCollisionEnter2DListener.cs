using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider2D))]
    public class TagsOnCollisionEnter2DListener : TagsEventFunctionsListener
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Invoke(other);
        }
    }
}
