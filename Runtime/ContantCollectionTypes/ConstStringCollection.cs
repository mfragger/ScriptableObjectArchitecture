using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Constant/string's")]
    public class ConstStringCollection : ConstantCollection<string>
    {
        [SerializeField]
        private string[] Value;

        public override string GetValue(int i) => Value[i];
    }
}
