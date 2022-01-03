using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace ScriptableObjectArchitecture.SceneManagement
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField]
        private LoadSceneSetting loadSceneSettings;

        public void LoadSceneAndMove()
        {
            //loadSceneSettings.LoadSceneAndMove();
        }
        public void LoadScene()
        {
            loadSceneSettings.LoadScene();
        }
    }
}
