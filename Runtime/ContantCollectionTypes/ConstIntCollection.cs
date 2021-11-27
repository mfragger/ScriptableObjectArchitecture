using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Constant/int's")]
    public class ConstIntCollection : ConstantCollection<int>
    {
        [SerializeField]
        private int[] Value;

        public override int GetValue(int i) => Value[i];
    }
}
