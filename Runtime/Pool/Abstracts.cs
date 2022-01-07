using UnityEngine;

namespace ScriptableObjectArchitecture.Pool
{
    public abstract class PartOfPool<T> : MonoBehaviour where T : Object
    {
        [SerializeReference]
        public ObjectPool<T> Pool;
    }

    public abstract class ObjectPool<T> : ScriptableObject where T : Object
    {
        public int initCapacity = 0;

        public int maxCapacity = 1;

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

        protected virtual void OnValidate()
        {
            if (maxCapacity <= initCapacity)
            {
                maxCapacity = initCapacity + 1;
            }
        }

        protected abstract void DestroyPooledObject(T obj);
        protected abstract void ReleasePooledObject(T obj);
        protected abstract void GetPooledObject(T obj);
        protected abstract T CreatePooledObject();
        public abstract T Get();
        public abstract void Release(T pooledObject);
        protected void SetCollectionCheck(bool isCollectionCheck) => this.isCollectionCheck = isCollectionCheck;

        public void SetPooledObject(T pooledObject) => this.pooledObject = pooledObject;

        protected void AssignPoolToPooled(ObjectPool<T> pool)
        {
            var go = (pooledObject as GameObject);
            if (go.TryGetComponent(out PartOfPool<T> partOfPool))
            {
                AssignPoolToPooled(partOfPool, pool);
            }
            else
            {
                AssignPoolToPooled(go.AddComponent<PartOfPool<T>>(), pool);
            }
        }
        private void AssignPoolToPooled(PartOfPool<T> partOfPool, ObjectPool<T> pool) => partOfPool.Pool = pool;

    }
}
