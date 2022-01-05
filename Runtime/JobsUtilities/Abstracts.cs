using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

namespace ScriptableObjectArchitecture.Jobs
{
    public abstract class Job : ScriptableObject
    {
        protected JobHandle jobHandle;

        [HideInInspector]
        public int refcount = 0;

        protected int count = 0;

        protected virtual void OnDisable()
        {
            Dispose();
        }

        protected abstract void Dispose();
    }

    public abstract class JobForTransform : Job
    {
        protected TransformAccessArray transformAccessArray;
    }
}
