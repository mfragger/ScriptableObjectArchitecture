using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Reference/Vector3's")]
    public class Vector3CollectionReference : Collection
    {
        public List<Vector3> Values;
    }
}
