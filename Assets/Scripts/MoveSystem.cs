using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float dt = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            translation.Value.y += moveSpeedComponent.moveSpeed * dt;

            if (translation.Value.y > 5f)
            {
                moveSpeedComponent.moveSpeed = -math.abs(moveSpeedComponent.moveSpeed);
            }
            
            if (translation.Value.y < -5f)
            {
                moveSpeedComponent.moveSpeed = math.abs(moveSpeedComponent.moveSpeed);
            }
        });
    }
}
