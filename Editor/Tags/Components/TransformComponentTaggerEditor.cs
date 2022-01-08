using ScriptableObjectArchitecture.Tags.Components;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(TransformTagger), true)]
    public class TransformComponentTaggerEditor : ObjectTaggerEditor<Transform, TransformTag> { }
}
