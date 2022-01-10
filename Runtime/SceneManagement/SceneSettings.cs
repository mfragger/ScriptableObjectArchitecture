using UnityEngine;
using UnityEngine.SceneManagement;
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
#endif
#if USE_NAUGHTYATTRIBUTES_2_1_1_OR_NEWER
using NaughtyAttributes;
#endif

namespace ScriptableObjectArchitecture.SceneManagement
{
    [CreateAssetMenu(menuName = "SO Architecture/Scene Settings", fileName = "New SceneSettings", order = 51)]
    public class SceneSettings : ScriptableObject
    {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        [SerializeField]
        internal AssetReference scene;

        public AsyncOperationHandle<SceneInstance> SceneHandleOperation;

        [SerializeField]
        private LoadSceneMode loadSceneMode;
#else
        [SerializeField]
        internal SceneReference scene;

        public AsyncOperation SceneHandleOperation;

        [SerializeField]
        private LoadSceneParameters loadSceneParameters;
#endif

        [Header("Additional Settings")]
        [SerializeField] private bool activateOnLoad = true;
        [SerializeField] private int priority = 100;
        [SerializeField] private bool makeActive = true;

        public void LoadScene()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            if (!SceneHandler.operationHandlers.ContainsKey(scene.AssetGUID))
            {
                SceneHandleOperation = scene.LoadSceneAsync(loadSceneMode, activateOnLoad, priority);
                if (makeActive)
                {
                    SceneHandleOperation.Completed += SceneHandleOperation_Completed;
                }
                SceneHandler.operationHandlers.Add(scene.AssetGUID, SceneHandleOperation);
            }
#else
            SceneHandleOperation = SceneManager.LoadSceneAsync(scene, loadSceneParameters);
            SceneHandleOperation.allowSceneActivation = activateOnLoad;
            SceneHandleOperation.priority = priority;
#endif
        }

#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        private void SceneHandleOperation_Completed(AsyncOperationHandle<SceneInstance> obj)
        {
            SceneManager.SetActiveScene(obj.Result.Scene);
        }
#endif
    }
}
