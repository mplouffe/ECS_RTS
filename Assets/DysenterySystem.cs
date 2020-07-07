using Unity.Entities;
using UnityEngine;

namespace ECS_RTS.DystenterySample
{
    public class DysenterySystem : SystemBase
    {
        EntityCommandBufferSystem barrier => World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        protected override void OnUpdate()
        {
            var currentSeconds = (float)Time.ElapsedTime;
            var commandBuffer = barrier.CreateCommandBuffer().ToConcurrent();

            Entities
                .ForEach((Entity entity, int entityInQueryIndex, in PlayerComponent player) =>
                {
                    if (player.Hygiene <= 0.6) return;

                    commandBuffer.AddComponent(entityInQueryIndex, entity, new Dysentary
                    {
                        DeathSecondsPoint = currentSeconds
                    });
                })
                .WithName("DysentaryContractJob")
                .ScheduleParallel();
            
            barrier.AddJobHandleForProducer(Dependency);

            Entities
                .WithAny<PlayerComponent>()
                .ForEach((Entity entity, int entityInQueryIndex, in Dysentary dysentery) =>
                {
                    if (currentSeconds - dysentery.DeathSecondsPoint < dysentery.DeathSecondsDuration) return;
                    commandBuffer.DestroyEntity(entityInQueryIndex, entity);
                })
                .WithName("DystentaryDeathJob")
                .ScheduleParallel();

            barrier.AddJobHandleForProducer(Dependency);
        }
    }
}
