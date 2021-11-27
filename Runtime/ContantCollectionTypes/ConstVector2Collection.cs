using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Constant/Vector2's")]
    public class ConstVector2Collection : ConstantCollection<Vector2>
    {
        [SerializeField]
        private Vector2[] Value;

        public override Vector2 GetValue(int i) => Value[i];
    }
}
