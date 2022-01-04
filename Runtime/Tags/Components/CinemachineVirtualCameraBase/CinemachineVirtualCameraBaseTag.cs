using Cinemachine;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components
{
#if USE_CINEMACHINE_2_8_4_OR_NEWER
    [CreateAssetMenu(menuName = "SO Architecture/Tags/Components/CameraComponent Tag", fileName = "New Tag Name")]
    public class CinemachineVirtualCameraBaseTag : Tag<CinemachineVirtualCameraBase> { }
#endif
}
