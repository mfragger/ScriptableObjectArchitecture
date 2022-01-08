using ScriptableObjectArchitecture.Tags.Components;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(TransformComponentTagger), true)]
    public class TransformComponentTaggerEditor : ObjectTaggerEditor<Transform, TransformTag> { }
}
