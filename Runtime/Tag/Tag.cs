using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public abstract class Tag<T> : ScriptableObject
    {
#if UNITY_2021_2_OR_NEWER
        public HashSet<T> TaggedObjects = new();
#else
        public HashSet<T> TaggedObjects = new HashSet<T>();
#endif
    }
}
