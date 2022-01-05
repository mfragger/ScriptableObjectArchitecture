using System.Linq;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components
{
    [CreateAssetMenu(menuName = "SO Architecture/Tags/Components/TransformComponent Tag", fileName = "New Tag Name")]
    public class TransformTag : Tag<Transform>
    {
        public void FirstOrDefault_Translate(Vector3 translation)
        {
            TaggedObjects.FirstOrDefault().Translate(translation);
        }

        public void All_Translate(Vector3 translation)
        {
            foreach (var transform in TaggedObjects)
            {
                transform.Translate(translation);
            }
        }

        public int GetFromFirstOrDefault_ChildCount()
        {
            return TaggedObjects.FirstOrDefault().childCount;
        }

        public int[] GetFromAll_ChildCount()
        {
            int[] result = new int[TaggedObjects.Count];
            var index = 0;
            foreach (var transform in TaggedObjects)
            {
                result[index++] = transform.childCount;
            }
            return result;
        }

        public void SetFromFirstOrDefault_SetPosition(Vector3 position)
        {
            TaggedObjects.FirstOrDefault().position = position;
        }

        public void SetFromAll_SetPosition(Vector3 position)
        {
            foreach (var transform in TaggedObjects)
            {
                transform.position = position;
            }
        }

        public void SetFromFirstOrDefault_SetPosition(Transform transform)
        {
            if (transform == null)
                return;

            TaggedObjects.FirstOrDefault().position = transform.position;
        }

        public void SetFromAll_SetPosition(Transform transform)
        {
            if (transform == null)
                return;

            foreach (var taggedTransform in TaggedObjects)
            {
                taggedTransform.position = transform.position;
            }
        }
    }
}
