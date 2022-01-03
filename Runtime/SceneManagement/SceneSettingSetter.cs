using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.SceneManagement
{
    public class SceneSettingSetter : MonoBehaviour
    {
        [SerializeField]
        private LoadSceneSetting sceneLinker;

        [SerializeField]
        private Transform spawnPoint;

        private void Awake()
        {
            Set();
        }

        private void OnValidate()
        {
            Set();
            EditorUtility.SetDirty(sceneLinker);
        }

        private void Set()
        {
            if (spawnPoint != null)
            {
                sceneLinker.SetTransform(spawnPoint.position);
            }
            else
            {
                sceneLinker.SetTransform(transform.position);
            }
            sceneLinker.SetSceneReference(gameObject.scene.name);
        }
    }
}
