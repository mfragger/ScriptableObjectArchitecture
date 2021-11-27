using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Reference/Vector3Int's")]
    public class Vector3IntCollectionReference : Collection
    {
        public List<Vector3Int> Values;
    }
}
