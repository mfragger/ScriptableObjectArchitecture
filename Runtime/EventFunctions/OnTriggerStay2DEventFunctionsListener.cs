using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions
{
    [RequireComponent(typeof(Collider2D))]
    public class OnTriggerStay2DEventFunctionsListener : EventFunctionsListener
    {
        private void OnTriggerStay2D(Collider2D other)
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
