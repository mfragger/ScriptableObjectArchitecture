using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Collection/Reference/AudioClips")]
    public class RefAudioClips : RefCollection<AudioClip, RefAudioClips> { }
}
