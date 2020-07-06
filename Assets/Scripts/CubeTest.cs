using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class CubeTest : MonoBehaviour
{
    private EntityManager _entityManager;

    [SerializeField]
    public GameObject Prefab;
    [SerializeField]
    public int NumberOfObjects = 1000;
    [SerializeField]
    public int XSpread = 10;
    [SerializeField]
    public int YSpread = 10;
    [SerializeField]
    public int ZSpread = 10;

    public void Start()
    {
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, settings);

        for (var i = 0; i < NumberOfObjects; i++)
        {
            var position = new Vector3(
                Random.Range(-XSpread, XSpread),
                Random.Range(-YSpread, YSpread),
                Random.Range(-ZSpread, ZSpread));

            var entityInstance = _entityManager.Instantiate(entity);

            _entityManager.SetComponentData(entityInstance, new Translation { Value = position });
        }
    }
}
