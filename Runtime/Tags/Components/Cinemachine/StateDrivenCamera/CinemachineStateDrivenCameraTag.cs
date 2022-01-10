#if USE_CINEMACHINE_2_8_4_OR_NEWER
using Cinemachine;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components.Cinemachine
{
    [CreateAssetMenu(menuName = "SO Architecture/Tags/Components/Cinemachine/StateDrivenCamera Tag", fileName = "New StateDrivenCamera Tag")]
    public class CinemachineStateDrivenCameraTag : Tag<CinemachineStateDrivenCamera> { }
}
#endif