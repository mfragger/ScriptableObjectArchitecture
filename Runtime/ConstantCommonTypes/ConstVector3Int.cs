using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Variable/Constant/Vector3Int")]
    public class ConstVector3Int : ConstantVariable<Vector3Int>
    {
        [SerializeField]
        private Vector3Int Value;

        public override Vector3Int GetValue() => Value;
    }
}
