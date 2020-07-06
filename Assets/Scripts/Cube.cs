using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Cube : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponent(entity, typeof(CubeComponent));
        dstManager.AddComponentData(entity, new MoveSpeedComponent { Value = Random.Range(0.1f, 1.0f) });
    }
}
