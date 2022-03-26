using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Variable/Reference/int")]
    public class RefInt : Variable<int, RefInt> { }
}
