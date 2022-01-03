using UnityEditor.Search.Providers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace ScriptableObjectArchitecture.SceneManagement
{
    [CreateAssetMenu]
    public class LoadSceneSetting : ScriptableObject
    {
        [SerializeField]
        private LoadSceneMode loadSceneMode;

        [SerializeField]
        private Vector3 worldPosition;

        [SerializeField]
        private AssetReference scene;

        private AsyncOperationHandle<SceneInstance> sceneHandleOperation;

        [SerializeField]
        private bool isLoaded;

        private Transform transform;

        private void OnValidate()
        {
            isLoaded = false;
        }

        public void SetSceneReference(string sceneName)
        {
            //scene = new AssetReference(sceneName);
        }

        public void SetTransform(Vector3 worldPosition)
        {
            this.worldPosition = worldPosition;
        }

        public void LoadSceneAndMove(Transform transform)
        {
            this.transform = transform;
        }

        public void LoadScene()
        {
            if (!isLoaded)
            {
                sceneHandleOperation = scene.LoadSceneAsync(loadSceneMode);
                sceneHandleOperation.Completed += LoadSceneSetting_Completed;
            }
        }

        private void LoadSceneSetting_Completed(AsyncOperationHandle<SceneInstance> obj)
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                if (transform != null)
                {
                    transform.position = worldPosition;
                }
                isLoaded = true;
            }
        }
    }
}
