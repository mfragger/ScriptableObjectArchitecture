using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Variable/Constant/Vector3")]
    public class ConstVector3 : ConstantVariable<Vector3>
    {
        [SerializeField]
        private Vector3 Value;

        public override Vector3 GetValue() => Value;
    }
}
