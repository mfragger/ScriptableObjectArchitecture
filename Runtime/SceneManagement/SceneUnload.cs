using UnityEngine.SceneManagement;
using UnityEngine;
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
using UnityEngine.AddressableAssets;
#endif

namespace ScriptableObjectArchitecture.SceneManagement
{
    public class SceneUnload : MonoBehaviour
    {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        [SerializeField]
        private AssetReference[] scene;
#endif

        public void UnloadScene()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            for (int i = 0; i < scene.Length; ++i)
            {
                if (SceneHandler.operationHandlers.ContainsKey(scene[i].AssetGUID))
                {
                    Addressables.UnloadSceneAsync(SceneHandler.operationHandlers[scene[i].AssetGUID]);
                    Addressables.Release(SceneHandler.operationHandlers[scene[i].AssetGUID]);
                    SceneHandler.operationHandlers.Remove(scene[i].AssetGUID);
                }
            }
#endif
        }
    }
}