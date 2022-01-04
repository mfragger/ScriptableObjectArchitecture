using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components
{
    [RequireComponent(typeof(Camera))]
    [DisallowMultipleComponent]
    public class CameraComponentTagger : ComponentTagger<Camera> { }
}
