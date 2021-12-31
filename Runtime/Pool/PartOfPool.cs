using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture.Pool
{
    [DisallowMultipleComponent]
    public class PartOfPool : MonoBehaviour
    {
        public ObjectPool<GameObject> Pool;
    }
}
