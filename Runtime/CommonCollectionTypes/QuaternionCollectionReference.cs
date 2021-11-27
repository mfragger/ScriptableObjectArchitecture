using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Reference/Quarternion's")]
    public class QuaternionCollectionReference : Collection
    {
        public List<Quaternion> Values;
    }
}
