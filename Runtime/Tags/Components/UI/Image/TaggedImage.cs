using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjectArchitecture.Tags.Components.UI
{
    public class TaggedImage : Image
    {
        [SerializeField]
        private ImageTag[] Tags;

        protected override void OnEnable()
        {
            base.OnEnable();
            for (int i = 0; i < Tags.Length; i++)
            {
                if (Tags[i] != null)
                {
                    Tags[i].TaggedObjects.Add(this);
                }
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            for (int i = 0; i < Tags.Length; i++)
            {
                if (Tags[i] != null)
                {
                    Tags[i].TaggedObjects.Remove(this);
                }
            }
        }
    }
}
