using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Variable/Reference/Vector3")]
    public class RefVector3 : Variable<Vector3, RefVector3> { }
}