using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace ScriptableObjectArchitecture.EventFunctions
{
    public abstract class EventFunctionsListener : ScriptableObjectEventListener { }

    public abstract class TagsEventFunctionsListener : EventFunctionsListener
    {
        [SerializeField]
        protected List<GameObjectTag> TagsToCheck;
    }

    public abstract class EventFunctionsListener<T0> : ScriptableObjectEventListener<T0> { }
    public abstract class TagsEventFunctionsListener<T0> : EventFunctionsListener<T0>
    {
        [SerializeField]
        protected List<GameObjectTag> TagsToCheck;
    }

    [DisallowMultipleComponent]
    public abstract class SceneTagsEventFunctionsListener : TagsEventFunctionsListener<LoadSceneMode> { }
}
