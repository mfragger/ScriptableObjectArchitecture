using UnityEngine;
using UnityEngine.SceneManagement;
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
#endif

namespace ScriptableObjectArchitecture.SceneManagement
{
    [CreateAssetMenu(menuName = "SO Architecture/Scene Settings", fileName = "New SceneSettings", order = 51)]
    public class SceneSettings : ScriptableObject
    {
        [SerializeField]
        private LoadSceneMode loadSceneMode;

#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        [SerializeField]
        internal AssetReference scene;

        public AsyncOperationHandle<SceneInstance> sceneHandleOperation;
#else
        [SerializeField]
        internal SceneReference sceneReference;

        public AsyncOperation SceneHandleOperation;
#endif

        private void OnEnable()
        {
        }

        public void LoadScene()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            sceneHandleOperation = scene.LoadSceneAsync(loadSceneMode);
#else
            SceneHandleOperation = SceneManager.LoadSceneAsync(sceneReference, loadSceneMode);
#endif
        }
    }
}
