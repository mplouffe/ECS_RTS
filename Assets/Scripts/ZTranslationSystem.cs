using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class ZTranslationSystem : JobComponentSystem
{
    [BurstCompile]
    [RequireComponentTag(typeof(CubeComponent))]
    struct TranslateJob : IJobForEach<Translation, MoveSpeedComponent>
    {
        [ReadOnly]
        public float DeltaTime;

        [ReadOnly]
        public bool MinusDirection;

        public void Execute(ref Translation translation, ref MoveSpeedComponent moveSpeed)
        {
            translation.Value += new float3(0f, 0f, (MinusDirection ? -1 : 1) * moveSpeed.Value * DeltaTime);
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new TranslateJob
        {
            MinusDirection = true,
            DeltaTime = Time.DeltaTime
        };

        return job.Schedule(this, inputDeps);
    }
}
