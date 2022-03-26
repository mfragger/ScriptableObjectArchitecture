using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Collection/Reference/Vector3Ints")]
    public class RefVector3Ints : RefCollection<Vector3Int, RefVector3Ints> { }
}
