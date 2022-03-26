using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Variable/Reference/Image")]
    public class RefImage : Variable<Image, RefImage> { }
}
