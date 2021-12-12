using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [DisallowMultipleComponent]
    [ExecuteAlways]
    public class GameObjectTagger : ObjectTagger<GameObject>
    {
        protected override void OnEnable()
        {
            for (int i = 0; i < Tags.Length; i++)
            {
                if (Tags[i] != null)
                {
                    Tags[i].TaggedObjects.Add(gameObject);
                }
            }
        }

        protected override void OnDisable()
        {
            for (int i = 0; i < Tags.Length; i++)
            {
                if (Tags[i] != null)
                {
                    Tags[i].TaggedObjects.Remove(gameObject);
                }
            }
        }
    }
}
