#if USE_ADDRESSABLES_1_16_19_OR_NEWER
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace ScriptableObjectArchitecture.SceneManagement
{
    internal static class SceneHandler
    {
        internal static Dictionary<string, AsyncOperationHandle<SceneInstance>> operationHandlers =
            new Dictionary<string, AsyncOperationHandle<SceneInstance>>();
    }
}
#endif