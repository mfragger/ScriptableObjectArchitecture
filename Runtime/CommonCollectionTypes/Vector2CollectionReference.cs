using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Reference/Vector2's")]
    public class Vector2CollectionReference : Collection
    {
        public List<Vector2> Values;
    }
}
