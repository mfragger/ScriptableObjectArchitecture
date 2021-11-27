using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [DisallowMultipleComponent]
    public class GameObjectTags : TagMonoBehaviour<GameObject>
    {
        protected override void OnEnable()
        {
            AddObject(gameObject);
        }

        protected override void OnDisable()
        {
            RemoveObject(gameObject);
        }

    }
}
