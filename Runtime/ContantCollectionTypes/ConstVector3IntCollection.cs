using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Constant/Vector3Int's")]
    public class ConstVector3IntCollection : ConstantCollection<Vector3Int>
    {
        [SerializeField]
        private Vector3Int[] Value;

        public override Vector3Int GetValue(int i) => Value[i];
    }
}
