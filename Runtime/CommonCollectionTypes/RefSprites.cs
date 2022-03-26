using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Collection/Reference/Sprites")]
    public class RefSprites : RefCollection<Sprite, RefSprites> { }
}
