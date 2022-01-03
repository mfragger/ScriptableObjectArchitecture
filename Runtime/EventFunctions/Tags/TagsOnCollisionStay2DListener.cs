using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider2D))]
    public class TagsOnCollisionStay2DListener : TagsEventFunctionsListener
    {
        private void OnCollisionStay2D(Collision2D other)
        {
            Invoke(other);
        }
    }
}
