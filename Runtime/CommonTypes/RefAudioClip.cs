using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Variable/Reference/AudioClip")]
    public class RefAudioClip : Variable<AudioClip, RefAudioClip> { }
}
