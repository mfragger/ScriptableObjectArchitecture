using System.Linq;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tags.Components
{
    [CreateAssetMenu(menuName = "SO Architecture/Tags/Components/GridComponent Tag", fileName = "New Tag Name")]
    public class GridTag : Tag<Grid>
    {
        public Vector3[] GetFromAll_GridNearestCellCenterLocal(Vector3 position)
        {
            Vector3[] result = new Vector3[TaggedObjects.Count];
            var index = 0;
            foreach (var grid in TaggedObjects)
            {
                Vector3Int cellPosition = grid.LocalToCell(position);
                result[index++] = grid.GetCellCenterLocal(cellPosition);
            }
            return result;
        }

        public Vector3 GetFromFirstOrDefault_GridNearestCellCenterLocal(Vector3 position)
        {
            var grid = TaggedObjects.FirstOrDefault();
            Vector3Int cellPosition = grid.LocalToCell(position);
            return grid.GetCellCenterLocal(cellPosition);
        }
    }
}
