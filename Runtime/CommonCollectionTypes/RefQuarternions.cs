using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Collection/Reference/Quarternions")]
    public class RefQuarternions : RefCollection<Quaternion, RefQuarternions> { }
}
