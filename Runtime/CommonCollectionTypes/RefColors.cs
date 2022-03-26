using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Collection/Reference/Colors")]
    public class RefColors : RefCollection<Color, RefColors> { }
}
