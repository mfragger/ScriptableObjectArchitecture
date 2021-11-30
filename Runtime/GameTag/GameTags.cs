using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [DisallowMultipleComponent]
    public class GameTags : MonoBehaviour
    {
        public Tag[] Tags;

        private void OnEnable()
        {
            for (int i = 0; i < Tags.Length; i++)
            {
                if (Tags[i] != null)
                {
                    Tags[i].Tagged.Add(gameObject);
                }
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < Tags.Length; i++)
            {
                if (Tags[i] != null)
                {
                    Tags[i].Tagged.Remove(gameObject);
                }
            }
        }
    }
}
