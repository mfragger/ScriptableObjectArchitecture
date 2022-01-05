using UnityEngine;
using UnityEngine.SceneManagement;
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
using UnityEngine.AddressableAssets;
#endif

namespace ScriptableObjectArchitecture.SceneManagement
{
    public class SceneUnload : MonoBehaviour
    {
        [SerializeField]
        private SceneSettings sceneSettings;

#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        public void UnloadScene()
        {
            Addressables.LoadResourceLocationsAsync(sceneSettings.scene).Completed += (loc) =>
            {
                var sceneId = loc.Result[0].InternalId;
                var isSceneLoaded = SceneManager.GetSceneByPath(sceneId).isLoaded;
                if (isSceneLoaded)
                {
                    if (sceneSettings.sceneHandleOperation.Equals(default))
                    {
                        SceneManager.UnloadSceneAsync(sceneId);
                    }
                    else
                    {
                        Addressables.UnloadSceneAsync(sceneSettings.sceneHandleOperation);
                    }
                }
            };
        }
#else
        public void UnloadScene()
        {
            if (SceneManager.GetSceneByBuildIndex(sceneSettings.buildIndex).isLoaded)
            {
                SceneManager.UnloadSceneAsync(sceneSettings.buildIndex);
            }
        }
#endif
    }
}
