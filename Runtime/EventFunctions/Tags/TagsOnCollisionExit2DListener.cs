using ScriptableObjectArchitecture.EventFunctions;
using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider2D))]
    public class TagsOnCollisionExit2DListener : TagsEventFunctionsListener
    {
        private void OnCollisionExit2D(Collision2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Response.Invoke();
                }
            }
        }
    }
}
