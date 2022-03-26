using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Variable/Reference/string")]
    public class RefString : Variable<string, RefString> { }
}
