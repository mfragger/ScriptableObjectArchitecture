using JetBrains.Annotations;
using JobsUtilities;
using ScriptableObjectArchitecture.Jobs;
using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace ScriptableObjectArchitecture.JobsUtilities
{
    [CreateAssetMenu(menuName = "Jobs/TransformTranslate/Dynamic", fileName = "New TransformTranslate Job")]
    public class TransformTranslate : JobForTransform
    {
        private NativeArray<float2> nativeContainer_Directions;
        private NativeArray<float> nativeContainer_Speed;

        public void AddAndSchedule(Transform transform, float2 direction, float deltaTime, float speed)
        {
            if (jobHandle.IsCompleted)
            {
                AddTransform(transform);
                AddDirection(direction);
                AddSpeed(speed);
                count++;

                if (count >= refcount)
                {
                    jobHandle = new TransformTranslateJob
                    {
                        DeltaTime = deltaTime,
                        Speeds = nativeContainer_Speed,
                        Directions = nativeContainer_Directions,
                    }.Schedule(transformAccessArray);
                }
            }
        }
        private void AddSpeed(float speed)
        {
            if (!nativeContainer_Speed.IsCreated)
            {
                nativeContainer_Speed = new NativeArray<float>(refcount, Allocator.TempJob);
            }
            nativeContainer_Speed[count] = speed;
        }

        private void AddDirection(float2 direction)
        {
            if (!nativeContainer_Directions.IsCreated)
            {
                nativeContainer_Directions = new NativeArray<float2>(refcount, Allocator.TempJob);
            }
            nativeContainer_Directions[count] = direction;
        }

        private void AddTransform(Transform transform)
        {
            if (!transformAccessArray.isCreated)
            {
                transformAccessArray = new TransformAccessArray(refcount);
            }
            transformAccessArray.Add(transform);
        }

        public void CompleteAndDispose()
        {
            count = math.clamp(count - 1, 0, refcount);
            if (count > 0)
            {
                return;
            }
            jobHandle.Complete();
            Dispose();
        }

        protected override void Dispose()
        {
            if (transformAccessArray.isCreated)
            {
                transformAccessArray.Dispose();
            }
            if (nativeContainer_Directions.IsCreated)
            {
                nativeContainer_Directions.Dispose();
            }
            if (nativeContainer_Speed.IsCreated)
            {
                nativeContainer_Speed.Dispose();
            }
        }
    }
}
