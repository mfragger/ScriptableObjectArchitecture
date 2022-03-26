using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Collection/Reference/ints")]
    public class RefInts : RefCollection<int, RefInts> { }
}
