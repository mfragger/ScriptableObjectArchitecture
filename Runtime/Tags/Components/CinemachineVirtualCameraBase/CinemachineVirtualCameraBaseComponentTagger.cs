#if USE_CINEMACHINE_2_8_4_OR_NEWER
using Cinemachine;
#endif
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components.Cinemachine
{
#if USE_CINEMACHINE_2_8_4_OR_NEWER
    [RequireComponent(typeof(CinemachineVirtualCameraBase))]
    [DisallowMultipleComponent]
    public class CinemachineVirtualCameraBaseComponentTagger : ComponentTagger<CinemachineVirtualCameraBase> { }
#endif
}
