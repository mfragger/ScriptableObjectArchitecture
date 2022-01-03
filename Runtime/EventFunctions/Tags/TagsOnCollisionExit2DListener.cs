using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider2D))]
    public class TagsOnCollisionExit2DListener : TagsEventFunctionsListener
    {
        private void OnCollisionExit2D(Collision2D other)
        {
            Invoke(other);
        }
    }
}
