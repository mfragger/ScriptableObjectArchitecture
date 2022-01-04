using Cinemachine;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components
{
#if USE_CINEMACHINE_2_8_4_OR_NEWER
    [RequireComponent(typeof(CinemachineVirtualCameraBase))]
    [DisallowMultipleComponent]
    public class CinemachineVirtualCameraBaseComponentTagger : ComponentTagger<CinemachineVirtualCameraBase> { }
#endif
}
