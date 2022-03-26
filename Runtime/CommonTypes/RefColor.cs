using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Variable/Reference/Color")]
    public class RefColor : Variable<Color, RefColor> { }
}
