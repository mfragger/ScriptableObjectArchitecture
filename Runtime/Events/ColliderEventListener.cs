using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture.Events
{
    public abstract class ColliderEventListener : ScriptableObjectEventListener
    {
        [SerializeField]
        protected List<GameObjectTag> TagsToCheck;
    }
}
