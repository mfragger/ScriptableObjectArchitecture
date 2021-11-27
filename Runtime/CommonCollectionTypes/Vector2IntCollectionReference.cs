using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Reference/Vector2Int's")]
    public class Vector2IntCollectionReference : Collection
    {
        public List<Vector2Int> Values;
    }
}
