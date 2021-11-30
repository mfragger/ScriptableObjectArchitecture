using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableObjectArchitecture
{
    public class SceneNodeBehaviour : MonoBehaviour
    {
        [SerializeField]
        private SceneNode sceneNode;

        private void Awake()
        {
            sceneNode.SceneIndex = SceneManager.GetSceneByName(gameObject.scene.name).buildIndex;
            sceneNode.locationToSpawn = transform.position;
        }
    }
}
