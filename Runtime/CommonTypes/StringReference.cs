using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Variable/Reference/string")]
    public class StringReference : Variable
    {
        public string Value;
    }
}
