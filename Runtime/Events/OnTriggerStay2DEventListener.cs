using UnityEngine;

namespace ScriptableObjectArchitecture.Events
{
    public class OnTriggerStay2DEventListener : ColliderEventListener
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                {
                    Response.Invoke();
                    break;
                }
            }
        }
    }
}
