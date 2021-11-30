using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu]
    public class SceneNode : ScriptableObject
    {
        public int SceneIndex;
        public Vector3 locationToSpawn;
    }
}
