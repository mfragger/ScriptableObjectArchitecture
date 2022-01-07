using UnityEditor;
using UnityEngine;
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
#else
using UnityEngine.SceneManagement;
#endif
#if ODIN_INSPECTOR || ODIN_INSPECTOR_3
using Sirenix.OdinInspector;
#endif

namespace ScriptableObjectArchitecture.SceneManagement
{
    public abstract class OnSceneLoad<T0> : EventListener<T0>
    {
#if ODIN_INSPECTOR || ODIN_INSPECTOR_3
        [InlineEditor]
#endif
        [SerializeField]
        internal SceneSettings loadSceneSetting;

        protected virtual void OnEnable()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            if (loadSceneSetting.SceneHandleOperation.IsValid())
            {
                loadSceneSetting.SceneHandleOperation.Completed += SceneHandleOperation_Completed;
            }
#else
            if (loadSceneSetting.SceneHandleOperation != null)
            {
                loadSceneSetting.SceneHandleOperation.completed += SceneHandleOperation_Completed;
            }
#endif
        }

#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        private void SceneHandleOperation_Completed(AsyncOperationHandle<SceneInstance> obj)
        {
            Respond();
        }
#else
        private void SceneHandleOperation_Completed(AsyncOperation obj)
        {
            Respond();
        }
#endif
        protected virtual void Respond()
        {
            for (int i = 0; i < Responses.Count; i++)
            {
                Responses[i].Response.Invoke(Responses[i].args0);
            }
        }
    }

    public abstract class OnSceneLoad<T0, T1> : EventListener<T0, T1>
    {
        [SerializeField]
        internal SceneSettings loadSceneSetting;

        private void OnEnable()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            if (loadSceneSetting.SceneHandleOperation.IsValid())
            {
                loadSceneSetting.SceneHandleOperation.Completed += SceneHandleOperation_Completed;
            }
#else
            if (loadSceneSetting.SceneHandleOperation != null)
            {
                loadSceneSetting.SceneHandleOperation.completed += SceneHandleOperation_Completed;
            }
#endif
        }

#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        private void SceneHandleOperation_Completed(AsyncOperationHandle<SceneInstance> obj)
        {
            Respond();
        }
#else
        private void SceneHandleOperation_Completed(AsyncOperation obj)
        {
            Respond();
        }
#endif
        private void Respond()
        {
            for (int i = 0; i < Responses.Count; i++)
            {
                Responses[i].Response.Invoke(Responses[i].args0, Responses[i].args1);
            }
        }
    }

    public abstract class OnSceneLoad<T0, T1, T2> : EventListener<T0, T1, T2>
    {
        [SerializeField]
        internal SceneSettings loadSceneSetting;

        private void OnEnable()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            if (loadSceneSetting.SceneHandleOperation.IsValid())
            {
                loadSceneSetting.SceneHandleOperation.Completed += SceneHandleOperation_Completed;
            }
#else
            if (loadSceneSetting.SceneHandleOperation != null)
            {
                loadSceneSetting.SceneHandleOperation.completed += SceneHandleOperation_Completed;
            }
#endif        
        }

#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        private void SceneHandleOperation_Completed(AsyncOperationHandle<SceneInstance> obj)
        {
            Respond();
        }
#else
        private void SceneHandleOperation_Completed(AsyncOperation obj)
        {
            Respond();
        }
#endif
        private void Respond()
        {
            for (int i = 0; i < Responses.Count; i++)
            {
                Responses[i].Response.Invoke(Responses[i].args0, Responses[i].args1, Responses[i].args2);
            }
        }
    }

    public abstract class OnSceneLoad<T0, T1, T2, T3> : EventListener<T0, T1, T2, T3>
    {
        [SerializeField]
        internal SceneSettings loadSceneSetting;

        private void OnEnable()
        {
#if USE_ADDRESSABLES_1_16_19_OR_NEWER
            if (loadSceneSetting.SceneHandleOperation.IsValid())
            {
                loadSceneSetting.SceneHandleOperation.Completed += SceneHandleOperation_Completed;
            }
#else
            if (loadSceneSetting.SceneHandleOperation != null)
            {
                loadSceneSetting.SceneHandleOperation.completed += SceneHandleOperation_Completed;
            }
#endif
        }

#if USE_ADDRESSABLES_1_16_19_OR_NEWER
        private void SceneHandleOperation_Completed(AsyncOperationHandle<SceneInstance> obj)
        {
            Respond();
        }
#else
        private void SceneHandleOperation_Completed(AsyncOperation obj)
        {
            Respond();
        }
#endif
        private void Respond()
        {
            for (int i = 0; i < Responses.Count; i++)
            {
                Responses[i].Response.Invoke(Responses[i].args0, Responses[i].args1, Responses[i].args2, Responses[i].args3);
            }
        }
    }
}
