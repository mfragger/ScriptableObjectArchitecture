using ScriptableObjectArchitecture.Tags.Components;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(GridTagger), true)]
    public class GridTaggerEditor : ObjectTaggerEditor<Grid, GridTag> { }
}
