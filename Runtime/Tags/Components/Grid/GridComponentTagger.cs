using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components
{
    [RequireComponent(typeof(Grid))]
    [DisallowMultipleComponent]
    public class GridComponentTagger : ComponentTagger<Grid> { }
}
