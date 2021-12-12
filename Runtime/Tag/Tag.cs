using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public abstract class Tag<T> : ScriptableObject
    {
        public HashSet<T> TaggedObjects = new();
    }
}
