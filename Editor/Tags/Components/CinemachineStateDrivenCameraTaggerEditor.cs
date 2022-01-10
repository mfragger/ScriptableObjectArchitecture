#if USE_CINEMACHINE_2_8_4_OR_NEWER
using UnityEditor;
using Cinemachine;
using ScriptableObjectArchitecture.Tags.Components.Cinemachine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(CinemachineStateDrivenCameraTagger), true)]
    public class CinemachineStateDrivenCameraTaggerEditor : ObjectTaggerEditor<CinemachineStateDrivenCamera, CinemachineStateDrivenCameraTag> { }
}
#endif
