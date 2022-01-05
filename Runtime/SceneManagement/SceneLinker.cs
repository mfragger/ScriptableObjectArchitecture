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
        private SceneSettings loadSceneSetting;

        [SerializeField]
        private Transform spawnPoint;

        [Header("When Scene Loaded Completely")]
        [SerializeField]
        private GameEvent gameEvent;

        private void Awake()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            if (loadSceneSetting.sceneHandleOperation.IsValid())
            {
                loadSceneSetting.sceneHandleOperation.Completed += SceneHandleOperation_Completed;
            }
#else
            if (loadSceneSetting.SceneHandleOperation != null)
            {
                loadSceneSetting.SceneHandleOperation.completed += SceneHandleOperation_completed;
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
            gameEvent.InvokeEvent();
            if (loadSceneSetting.IsTransformSet)
            {
                loadSceneSetting.transform.position = spawnPoint.position;
                return;
            }
        }

        private void OnValidate()
        {
            Set();
        }

        private void Set()
        {
            if (loadSceneSetting != null)
            {
                loadSceneSetting.SetSceneReference(gameObject.scene.name);
                EditorUtility.SetDirty(loadSceneSetting);
            }
        }
    }
}
