using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [RequireComponent(typeof(Grid))]
    [DisallowMultipleComponent]
    public class GridComponentTagger : ComponentTagger<Grid> { }
}
