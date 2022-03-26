using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Collection/Reference/Images")]
    public class RefImages : RefCollection<Image, RefImages> { }
}
