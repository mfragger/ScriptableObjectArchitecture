#if USE_CINEMACHINE_2_8_4_OR_NEWER
using UnityEditor;
using Cinemachine;
using ScriptableObjectArchitecture.Tags.Components.Cinemachine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(CinemachineClearShotTagger), true)]
    public class CinemachineClearShotTaggerEditor : ObjectTaggerEditor<CinemachineClearShot, CinemachineClearShotTag> { }
}
#endif
