using UnityEngine;

namespace ScriptableObjectArchitecture.Pool
{
    public abstract class ObjectPool<T> : ScriptableObject where T : UnityEngine.Object
    {
        public int initCapacity;

        public int maxCapacity;

        public T pooledObject;

        protected UnityEngine.Pool.ObjectPool<T> pool;

        public bool isCollectionCheck = true;

        protected virtual void OnEnable()
        {
            pool = new UnityEngine.Pool.ObjectPool<T>(
                CreatePooledObject,
                GetPooledObject,
                ReleasePooledObject,
                DestroyPooledObject,
                isCollectionCheck,
                initCapacity,
                maxCapacity);
        }

        protected abstract void DestroyPooledObject(T obj);
        protected abstract void ReleasePooledObject(T obj);
        protected abstract void GetPooledObject(T obj);
        protected abstract T CreatePooledObject();
        public abstract T Get();
        public abstract void Release(T pooledObject);
        protected void SetCollectionCheck(bool isCollectionCheck)
        {
            this.isCollectionCheck = isCollectionCheck;
        }
        public void SetPooledObject(T pooledObject)
        {
            this.pooledObject = pooledObject;
        }
    }
}