using UnityEngine;

namespace ScriptableObjectArchitecture.Jobs
{
    public abstract class JobMonoBehaviour<T> : MonoBehaviour where T : Job
    {
        [SerializeField]
        protected T Job;

        protected virtual void OnEnable()
        {
            Job.refcount++;
        }

        protected virtual void OnDisable()
        {
            Job.refcount--;
        }

        protected abstract void Update();

        protected abstract void LateUpdate();
    }
}
