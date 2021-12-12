using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Tags/GameObject Tag", fileName = "New Tag Name")]
    public class GameObjectTag : Tag<GameObject> { }
}
