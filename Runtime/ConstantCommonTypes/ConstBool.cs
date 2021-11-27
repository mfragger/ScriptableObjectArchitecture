using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Variable/Constant/bool")]
    public class ConstBool : ConstantVariable<bool>
    {
        [SerializeField]
        private bool Value;

        public override bool GetValue() => Value;
    }
}
