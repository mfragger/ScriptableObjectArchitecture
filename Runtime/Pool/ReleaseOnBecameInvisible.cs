using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture.Pool
{
    [RequireComponent(typeof(PartOfPool))]
    [DisallowMultipleComponent]
    public class ReleaseOnBecameInvisible : MonoBehaviour
    {
        [SerializeField]
        private PartOfPool partOfPool;

        private void OnBecameInvisible()
        {
            partOfPool.Pool.Release(gameObject);
        }
        private void OnValidate()
        {
            partOfPool = GetComponent<PartOfPool>();
        }
    }
}
