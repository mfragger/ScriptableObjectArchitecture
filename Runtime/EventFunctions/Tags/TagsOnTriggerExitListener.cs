using ScriptableObjectArchitecture.EventFunctions;
using UnityEngine;

namespace ScriptableObjectArchitecture.EventFunctions.Tags
{
    [RequireComponent(typeof(Collider))]
    public class TagsOnTriggerExitListener : TagsEventFunctionsListener
    {
        private void OnTriggerExit(Collider other)
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
