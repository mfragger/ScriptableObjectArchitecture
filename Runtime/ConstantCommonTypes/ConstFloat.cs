using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Variable/Constant/float")]
    public class ConstFloat : ConstantVariable<float>
    {
        [SerializeField]
        private float Value;

        public override float GetValue() => Value;
    }
}
