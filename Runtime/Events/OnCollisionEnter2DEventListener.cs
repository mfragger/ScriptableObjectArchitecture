using UnityEngine.Events;
using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture.Events
{
    [RequireComponent(typeof(Collider2D))]
    public class OnCollisionEnter2DEventListener : ColliderEventListener
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                //Would be faster if we use hashset
                if (TagsToCheck[i].TaggedObjects.Contains(other.gameObject))
                    Response.Invoke();
            }
        }
    }
}
