using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Collection/Reference/GameObjects")]
    public class RefGameObjects : RefCollection<GameObject, RefGameObjects> { }
}
