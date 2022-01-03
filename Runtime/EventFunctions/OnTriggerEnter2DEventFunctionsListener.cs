using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.EventFunctions
{
    [RequireComponent(typeof(Collider2D))]
    public class OnTriggerEnter2DEventFunctionsListener : EventFunctionsListener
    {
        private void OnTriggerEnter2D(Collider2D other)
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
