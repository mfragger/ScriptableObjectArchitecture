using System.Linq;
using UnityEngine;

namespace ScriptableObjectArchitecture.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private SceneSettings loadSceneSettings;

        public void LoadScene()
        {
            loadSceneSettings.LoadScene();
        }
    }
}
