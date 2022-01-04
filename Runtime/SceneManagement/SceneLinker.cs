using UnityEditor;
using UnityEngine;
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
#else
using UnityEngine.SceneManagement;
#endif
namespace ScriptableObjectArchitecture.SceneManagement
{
    public class SceneLinker : MonoBehaviour
    {
        [SerializeField]
        private LoadSceneSetting loadSceneSetting;

        [SerializeField]
        private Transform spawnPoint;

        private void Awake()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            if (loadSceneSetting.sceneHandleOperation.IsValid())
            {
                loadSceneSetting.sceneHandleOperation.Completed += SceneHandleOperation_Completed;
            }
#else
            if (loadSceneSetting.sceneHandleOperation != null)
            {
                loadSceneSetting.sceneHandleOperation.completed += SceneHandleOperation_completed;
            }
#endif
        }

#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        private void SceneHandleOperation_Completed(AsyncOperationHandle<SceneInstance> obj)
        {
            Move();
        }
#else
        private void SceneHandleOperation_completed(AsyncOperation obj)
        {
            Move();
        }
#endif

        private void Move()
        {
            if (loadSceneSetting.isTransformSet)
            {
                loadSceneSetting.transform.position = spawnPoint.position;
                return;
            }
        }

        private void OnValidate()
        {
            Set();
            EditorUtility.SetDirty(loadSceneSetting);
        }

        private void Set()
        {
            loadSceneSetting.SetSceneReference(gameObject.scene.name);
        }
    }
}
