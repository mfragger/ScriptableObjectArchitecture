using UnityEngine;
using UnityEngine.SceneManagement;
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
#else
using UnityEngine.SceneManagement;
#endif

namespace ScriptableObjectArchitecture.SceneManagement
{
    [CreateAssetMenu]
    public class LoadSceneSetting : ScriptableObject
    {
        [SerializeField]
        private LoadSceneMode loadSceneMode;

#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        [SerializeField]
        private AssetReference scene;

        public AsyncOperationHandle<SceneInstance> sceneHandleOperation = default;
#else
        [SerializeField]
        private int buildIndex;

        public AsyncOperation sceneHandleOperation;
#endif
        [HideInInspector]
        public bool isTransformSet;

        [HideInInspector]
        public Transform transform;

        public void SetSceneReference(string sceneName)
        {
            //scene = new AssetReference(sceneName);
        }

        public void SetTransformToMove(Transform transform)
        {
            this.transform = transform;
            isTransformSet = true;
        }

        public void LoadScene()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            sceneHandleOperation = scene.LoadSceneAsync(loadSceneMode);
#else
            sceneHandleOperation = SceneManager.LoadSceneAsync(buildIndex, loadSceneMode);
#endif
        }
    }
}
