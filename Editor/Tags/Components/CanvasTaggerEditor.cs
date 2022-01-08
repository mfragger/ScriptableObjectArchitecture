using ScriptableObjectArchitecture.Tags.Components.UI;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(CanvasTagger), true)]
    public class CanvasTaggerEditor : ObjectTaggerEditor<Canvas, CanvasTag> { }
}
