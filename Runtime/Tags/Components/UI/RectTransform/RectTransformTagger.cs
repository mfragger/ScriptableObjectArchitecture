using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components.UI
{
    [RequireComponent(typeof(RectTransform))]
    [DisallowMultipleComponent]
    public class RectTransformTagger : ComponentTagger<RectTransform> { }
}
