using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions
{
    [RequireComponent(typeof(Collider2D))]
    public class OnCollisionStay2DEventFunctionsListener : EventFunctionsListener
    {
        private void OnCollisionStay2D(Collision2D other)
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
