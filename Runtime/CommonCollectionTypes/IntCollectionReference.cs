using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Collection/Reference/int's")]
    public class IntCollectionReference : Collection
    {
        public List<int> Values;
    }
}
