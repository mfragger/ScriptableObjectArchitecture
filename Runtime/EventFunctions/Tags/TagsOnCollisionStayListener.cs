using ScriptableObjectArchitecture.EventFunctions;
using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider))]
    public class TagsOnCollisionStayListener : TagsEventFunctionsListener
    {
        private void OnCollisionStay(Collision other)
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
