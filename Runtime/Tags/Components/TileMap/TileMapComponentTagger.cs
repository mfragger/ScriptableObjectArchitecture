using UnityEngine;
using UnityEngine.Tilemaps;

namespace ScriptableObjectArchitecture.Tags.Components
{
    [RequireComponent(typeof(Tilemap))]
    [DisallowMultipleComponent]
    public class TileMapComponentTagger : ComponentTagger<Tilemap> { }
}
