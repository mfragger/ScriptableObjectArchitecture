using System.Linq;
using UnityEngine;

namespace ScriptableObjectArchitecture.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private SceneSettings loadSceneSettings;

        public void LoadSceneAndMove(GameObjectTag tagToMove)
        {
            loadSceneSettings.SetTransformToMove(tagToMove.TaggedObjects.FirstOrDefault().transform);
            LoadScene();
        }

        public void LoadScene()
        {
            loadSceneSettings.LoadScene();
        }
    }
}
