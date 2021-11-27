using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Constant/Quarternion's")]
    public class ConstQuaternionCollection : ConstantCollection<Quaternion>
    {
        [SerializeField]
        private Quaternion[] Value;

        public override Quaternion GetValue(int i) => Value[i];
    }
}
