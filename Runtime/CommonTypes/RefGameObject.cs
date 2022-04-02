using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Variable/Reference/GameObject")]
    public class RefGameObject : Variable<GameObject, RefGameObject> { }
}
