#if USE_CINEMACHINE_2_8_4_OR_NEWER
using Cinemachine;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components.Cinemachine
{
    [RequireComponent(typeof(CinemachineStateDrivenCamera))]
    [DisallowMultipleComponent]
    public class CinemachineStateDrivenCameraTagger : ComponentTagger<CinemachineStateDrivenCamera> { }
}
#endif