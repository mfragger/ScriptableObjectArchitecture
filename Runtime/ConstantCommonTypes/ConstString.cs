using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Variable/Constant/string")]
    public class ConstString : ConstantVariable<string>
    {
        [SerializeField]
        private string Value;

        public override string GetValue() => Value;
    }
}
