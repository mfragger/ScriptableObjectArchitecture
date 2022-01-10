#if USE_CINEMACHINE_2_8_4_OR_NEWER
using Cinemachine;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components.Cinemachine
{
    [CreateAssetMenu(menuName = "SO Architecture/Tags/Components/Cinemachine/VirtualCamera Tag", fileName = "New VirtualCamera Tag")]
    public class CinemachineVirtualCameraTag : Tag<CinemachineVirtualCamera> { }
}
#endif