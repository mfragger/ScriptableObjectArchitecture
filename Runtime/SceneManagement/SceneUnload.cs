using UnityEngine;
using UnityEngine.SceneManagement;
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
using UnityEngine.AddressableAssets;
#endif
#if ODIN_INSPECTOR || ODIN_INSPECTOR_3
using Sirenix.OdinInspector;
#endif

namespace ScriptableObjectArchitecture.SceneManagement
{
    public class SceneUnload : MonoBehaviour
    {
#if ODIN_INSPECTOR || ODIN_INSPECTOR_3
        [InlineEditor]
#endif
        [SerializeField]
        private SceneSettings sceneSettings;

        public void UnloadScene()
        {
            sceneSettings.UnloadScene();
        }
    }
}
