#if USE_CINEMACHINE_2_8_4_OR_NEWER
using Cinemachine;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components.Cinemachine
{
    [CreateAssetMenu(menuName = "SO Architecture/Tags/Components/Cinemachine/MixingCamera Tag", fileName = "New MixingCamera Tag")]
    public class CinemachineMixingCameraTag : Tag<CinemachineMixingCamera> { }
}
#endif