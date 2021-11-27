using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Variable/Constant/Vector2Int")]
    public class ConstVector2Int : ConstantVariable<Vector2Int>
    {
        [SerializeField]
        private Vector2Int Value;

        public override Vector2Int GetValue() => Value;
    }
}
