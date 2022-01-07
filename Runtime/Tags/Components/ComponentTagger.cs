using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components
{
    public abstract class ComponentTagger<T> : ObjectTagger<T>
    {
        [SerializeField]
        protected T Component;

        private void OnValidate()
        {
            Component = GetComponent<T>();
            EditorUtility.SetDirty(this);
        }

        protected override void OnEnable()
        {
            for (int i = 0; i < Tags.Length; i++)
            {
                if (Tags[i] != null)
                {
                    Tags[i].TaggedObjects.Add(Component);
                }
            }
        }

        protected override void OnDisable()
        {
            for (int i = 0; i < Tags.Length; i++)
            {
                if (Tags[i] != null)
                {
                    Tags[i].TaggedObjects.Remove(Component);
                }
            }
        }
    }
}
