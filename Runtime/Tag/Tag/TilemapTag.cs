using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Tags/Components/TilemapComponent Tag", fileName = "New Tag Name")]
    public class TilemapTag : Tag<Tilemap>
    {
        public Vector3Int[] GetFromAll_WorldToCell(Vector3 position)
        {
            Vector3Int[] result = new Vector3Int[TaggedObjects.Count];
            var index = 0;
            foreach (var tile in TaggedObjects)
            {
                result[index++] = tile.WorldToCell(position);
            }
            return result;
        }

        public Vector3Int GetFromFirstOrDefault_WorldToCell(Vector3 position)
        {
            var tilemap = TaggedObjects.FirstOrDefault();
            return tilemap.WorldToCell(position);
        }

        public bool[] GetFromAll_HasTile(Vector3Int position)
        {
            bool[] result = new bool[TaggedObjects.Count];
            var index = 0;
            foreach (var tile in TaggedObjects)
            {
                result[index++] = tile.HasTile(position);
            }
            return result;
        }

        public bool GetFromFirstOrDefault_HasTile(Vector3Int position)
        {
            var tilemap = TaggedObjects.FirstOrDefault();
            return tilemap.HasTile(position);
        }
    }
}
