using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Constant/Vector3's")]
    public class ConstVector3Collection : ConstantCollection<Vector3>
    {
        [SerializeField]
        private Vector3[] Value;

        public override Vector3 GetValue(int i) => Value[i];
    }
}
