using Unity.Mathematics;
using UnityEngine;

namespace ScriptableObjectArchitecture.JobsUtilities
{
    interface IJobSOForTransformTranslate
    {
        void AddAndSchedule(Transform transform, float2 direction, float deltaTime, float speed);
        void CompleteAndDispose();
    }
}
