using ScriptableObjectArchitecture.EventFunctions;
using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider))]
    public class TagsOnCollisionExitListener : TagsEventFunctionsListener
    {
        private void OnCollisionExit(Collision other)
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
