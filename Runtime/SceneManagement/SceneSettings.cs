using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.AI;
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
        [SerializeField] private NavMeshData navMeshData;
        private NavMeshDataInstance navMeshDataInstance;

        public void LoadScene()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            SceneHandleOperation = scene.LoadSceneAsync(loadSceneMode, activateOnLoad, priority);
#else
            SceneHandleOperation = SceneManager.LoadSceneAsync(scene, loadSceneParameters);
#endif
        }

        public void UnloadScene()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            SceneHandleOperation = scene.UnLoadScene();
#else
            SceneHandleOperation = SceneManager.UnloadSceneAsync(scene);
#endif
        }

        public void LoadNavMesh()
        {
            navMeshDataInstance = NavMesh.AddNavMeshData(navMeshData);
        }

        public void UnloadNavMesh()
        {
            if (navMeshDataInstance.Equals(default))
                UnloadAllNavMesh();
            NavMesh.RemoveNavMeshData(navMeshDataInstance);
        }

        public void UnloadAllNavMesh()
        {
            NavMesh.RemoveAllNavMeshData();
        }
    }
}
