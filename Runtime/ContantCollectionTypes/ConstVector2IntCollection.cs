using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Constant/Vector2Int's")]
    public class ConstVector2IntCollection : ConstantCollection<Vector2Int>
    {
        [SerializeField]
        private Vector2Int[] Value;

        public override Vector2Int GetValue(int i) => Value[i];
    }
}
