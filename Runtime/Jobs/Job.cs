using UnityEngine;

namespace ScriptableObjectArchitecture.Jobs
{
    public abstract class Job : ScriptableObject
    {
        [HideInInspector]
        public int refcount = 0;

        protected int count = 0;
    }
}
