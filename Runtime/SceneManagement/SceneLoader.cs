#if ODIN_INSPECTOR_3 || ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace ScriptableObjectArchitecture.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
#if ODIN_INSPECTOR_3 || ODIN_INSPECTOR
        [InlineEditor]
#endif
        [SerializeField]
        private SceneSettings loadSceneSettings;

        public void LoadScene()
        {
            loadSceneSettings.LoadScene();
        }
    }
}
