using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Variable/Reference/Quaternion")]
    public class QuaternionReference : Variable
    {
        public Quaternion Value;
    }
}
