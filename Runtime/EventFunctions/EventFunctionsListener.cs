using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture.EventFunctions
{
    public abstract class EventFunctionsListener : ScriptableObjectEventListener
    {
        [SerializeField]
        protected List<GameObjectTag> TagsToCheck;
    }
}
