#if USE_CINEMACHINE_2_8_4_OR_NEWER
using UnityEditor;
using Cinemachine;
using ScriptableObjectArchitecture.Tags.Components.Cinemachine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(CinemachineFreeLookTagger), true)]
    public class CinemachineFreeLookTaggerEditor : ObjectTaggerEditor<CinemachineFreeLook, CinemachineFreeLookTag> { }
}
#endif
