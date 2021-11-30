using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "SO Architecture/Tag", fileName = "New Tag Name")]
    public class Tag : ScriptableObject
    {
        public HashSet<GameObject> Tagged = new HashSet<GameObject>();

        //public SerializedHashSet<GameObject> stuff;
    }
}