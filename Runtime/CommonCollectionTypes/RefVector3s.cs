using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Collection/Reference/Vector3s")]
    public class RefVector3s : RefCollection<Vector3, RefVector3s> { }
}
