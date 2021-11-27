using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Variable/Constant/Quarternion")]
    public class ConstQuaternion : ConstantVariable<Quaternion>
    {
        [SerializeField]
        private Quaternion Value;

        public override Quaternion GetValue()
        {
            return Value;
        }
    }
}
