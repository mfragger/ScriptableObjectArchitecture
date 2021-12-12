using UnityEngine;
using UnityEngine.Tilemaps;

namespace ScriptableObjectArchitecture
{
    [RequireComponent(typeof(Tilemap))]
    [DisallowMultipleComponent]
    public class TileMapComponentTagger : ComponentTagger<Tilemap> { }
}
