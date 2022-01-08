using ScriptableObjectArchitecture.Tags.Components;
using UnityEditor;
using UnityEngine.Tilemaps;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(TilemapTagger), true)]
    public class TilemapTaggerEditor : ObjectTaggerEditor<Tilemap, TilemapTag> { }
}
