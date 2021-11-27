using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Variable/Constant/int")]
    public class ConstInt : ConstantVariable<int>
    {
        [SerializeField]
        private int Value;

        public override int GetValue() => Value;
    }
}
