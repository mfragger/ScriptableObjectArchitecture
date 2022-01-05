using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

namespace ScriptableObjectArchitecture.Pool
{
    public abstract class ObjectPool<T> : ScriptableObject where T : Object
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

        protected void AssignPoolToPooled(ObjectPool<GameObject> pool)
        {
            var go = (pooledObject as GameObject);
            if (go.TryGetComponent(out PartOfPool partOfPool))
            {
                AssignPoolToPooled(partOfPool, pool);
            }
            else
            {
                AssignPoolToPooled(go.AddComponent<PartOfPool>(), pool);
            }
        }
        private void AssignPoolToPooled(PartOfPool partOfPool, ObjectPool<GameObject> pool)
        {
            partOfPool.Pool = pool;
        }
    }
}