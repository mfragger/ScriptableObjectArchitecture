using ScriptableObjectArchitecture.Tags.Components.UI;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(RectTransformTagger), true)]
    public class RectTransformTaggerEditor : ObjectTaggerEditor<RectTransform, RectTransformTag> { }
}
