using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Collection/Reference/Vector2Ints")]
    public class RefVector2Ints : RefCollection<Vector2Int, RefVector2Ints> { }
}
