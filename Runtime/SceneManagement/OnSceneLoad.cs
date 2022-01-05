using UnityEngine;
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
#else
using UnityEngine.SceneManagement;
#endif

namespace ScriptableObjectArchitecture.SceneManagement
{
    public class OnSceneLoad : EventListener
    {
        [SerializeField]
        internal SceneSettings loadSceneSetting;

        private void OnEnable()
        {
            if (loadSceneSetting == null)
                return;
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            if (loadSceneSetting.sceneHandleOperation.IsValid())
            {
                loadSceneSetting.sceneHandleOperation.Completed += SceneHandleOperation_Completed;
            }
#else
            if (loadSceneSetting.SceneHandleOperation != null)
            {
                loadSceneSetting.SceneHandleOperation.completed += SceneHandleOperation_Completed;
            }
#endif
        }

#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        private void SceneHandleOperation_Completed(AsyncOperationHandle<SceneInstance> obj)
        {
            Respond();
        }
#else
        private void SceneHandleOperation_Completed(AsyncOperation obj)
        {
            Respond();
        }
#endif
        private void Respond()
        {
            Response.Invoke();
        }
    }
}
