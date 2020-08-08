using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class Testing : MonoBehaviour
{
    [SerializeField]
    private Mesh mesh;

    [SerializeField]
    private Material material;

    private void Start()
    {
        Debug.Log("Sanity Check");
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype entityArchetype = entityArchetype = entityManager.CreateArchetype(
                typeof(LevelComponent),
                typeof(MoveSpeedComponent),
                typeof(Translation),
                typeof(RenderMesh),
                typeof(LocalToWorld),
                typeof(RenderBounds)
            );
        NativeArray<Entity> entityArray = new NativeArray<Entity>(10000, Allocator.Temp);

        entityManager.CreateEntity(entityArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];
            entityManager.SetComponentData(entity,
                new LevelComponent {
                    level = UnityEngine.Random.Range(10f, 20f)
                });
            entityManager.SetComponentData(entity,
                new MoveSpeedComponent {
                    moveSpeed = UnityEngine.Random.Range(1f, 5f)
                });
            entityManager.SetComponentData(entity,
                new Translation
                {
                    Value = new float3(
                        UnityEngine.Random.Range(-8, 8f),
                        UnityEngine.Random.Range(-5, 5f),
                        0)
                });

            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = material
            });
        }

        entityArray.Dispose();
    }
}
