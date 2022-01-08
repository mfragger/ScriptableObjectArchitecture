using ScriptableObjectArchitecture.Tags.Components;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(CameraTagger), true)]
    public class CameraTaggerEditor : ObjectTaggerEditor<Camera, CameraTag> { }
}
