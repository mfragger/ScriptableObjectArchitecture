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

        public void UnloadScene()
        {
            sceneSettings.UnloadScene();
        }
    }
}
