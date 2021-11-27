using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Constant/bool's")]
    public class ConstBoolCollection : ConstantCollection<bool>
    {
        [SerializeField]
        private bool[] Value;

        public override bool GetValue(int i) => Value[i];
    }
}
