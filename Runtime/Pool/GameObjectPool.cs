using UnityEngine;

namespace ScriptableObjectArchitecture.Pool
{
    [CreateAssetMenu(menuName = "SO Architecture/Object Pool/GameObject Pool", fileName = "New GameObject Pool")]
    public class GameObjectPool : ObjectPool<GameObject>
    {
        protected override GameObject CreatePooledObject() => Instantiate(pooledObject);
        protected override void GetPooledObject(GameObject obj) => obj.SetActive(true);

        protected override void ReleasePooledObject(GameObject obj) => obj.SetActive(false);

        protected override void DestroyPooledObject(GameObject obj) => Destroy(obj);

        public override GameObject Get() => pool.Get();
        public override void Release(GameObject obj) => pool.Release(obj);

        protected override void OnEnable()
        {
            base.OnEnable();
            AssignPoolToPooled(this);
        }
        protected override void OnValidate()
        {
            base.OnValidate();
            AssignPoolToPooled(this);
        }
    }
}