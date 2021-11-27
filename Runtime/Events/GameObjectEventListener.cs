using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public class GameObjectEventListener : GameEventListener<GameObjectEvent>
    {
        protected override void OnEnable()
        {
            GameEvent.Register(this);
        }

        protected override void OnDisable()
        {
            GameEvent.Unregister(this);
        }
    }
}