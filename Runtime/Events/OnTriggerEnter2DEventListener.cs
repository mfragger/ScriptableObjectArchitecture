using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.Events
{
    public class OnTriggerEnter2DEventListener : ColliderEventListener
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            for (int i = 0; i < TagsToCheck.Count; i++)
            {
                if (TagsToCheck[i].Tagged.Contains(other.gameObject))
                    Response.Invoke();
            }
        }
    }
}
