using UnityEngine.Events;
using UnityEngine;
using ScriptableObjectArchitecture.EventFunctions;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider2D))]
    public class TagsOnCollisionEnter2DListener : TagsEventFunctionsListener
    {
        private void OnCollisionEnter2D(Collision2D other)
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
