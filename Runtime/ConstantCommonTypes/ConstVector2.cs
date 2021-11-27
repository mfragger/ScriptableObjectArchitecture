using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Variable/Constant/Vector2")]
    public class ConstVector2 : ConstantVariable<Vector2>
    {
        [SerializeField]
        private Vector2 Value;

        public override Vector2 GetValue() => Value;
    }
}
