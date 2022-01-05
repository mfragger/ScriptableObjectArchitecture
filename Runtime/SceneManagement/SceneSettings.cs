using UnityEngine;
using UnityEngine.SceneManagement;
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
#endif

namespace ScriptableObjectArchitecture.SceneManagement
{
    [CreateAssetMenu]
    public class SceneSettings : ScriptableObject
    {
        [SerializeField]
        private LoadSceneMode loadSceneMode;

#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        [SerializeField]
        internal AssetReference scene;

        public AsyncOperationHandle<SceneInstance> sceneHandleOperation = default;
#else
        [SerializeField]
        internal int buildIndex;

        public AsyncOperation SceneHandleOperation;
#endif
        [HideInInspector]
        public bool IsTransformSet;

        [HideInInspector]
        public Transform transform;

        public void SetSceneReference(string sceneName)
        {
            //scene = new AssetReference(sceneName);
        }

        public void SetTransformToMove(Transform transform)
        {
            this.transform = transform;
            IsTransformSet = true;
        }

        public void LoadScene()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            sceneHandleOperation = scene.LoadSceneAsync(loadSceneMode);
#else
            SceneHandleOperation = SceneManager.LoadSceneAsync(buildIndex, loadSceneMode);
#endif
        }
    }
}
