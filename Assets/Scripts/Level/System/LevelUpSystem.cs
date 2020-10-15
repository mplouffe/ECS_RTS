using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class LevelUpSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float dt = Time.DeltaTime;
        Entities.ForEach((ref LevelComponent levelComponent) =>
        {
            levelComponent.level += 1f * dt;
        });
    }
}
