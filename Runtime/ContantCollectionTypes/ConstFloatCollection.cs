using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Constant/float's")]
    public class ConstFloatCollection : ConstantCollection<float>
    {
        [SerializeField]
        private float[] Value;

        public override float GetValue(int i) => Value[i];
    }
}
