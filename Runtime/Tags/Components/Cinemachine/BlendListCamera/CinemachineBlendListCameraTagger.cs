#if USE_CINEMACHINE_2_8_4_OR_NEWER
using Cinemachine;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components.Cinemachine
{
    [RequireComponent(typeof(CinemachineBlendListCamera))]
    [DisallowMultipleComponent]
    public class CinemachineBlendListCameraTagger : ComponentTagger<CinemachineBlendListCamera> { }
}
#endif