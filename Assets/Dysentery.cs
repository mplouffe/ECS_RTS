using Unity.Entities;

public struct Dysentary : IComponentData
{
    public float DeathSecondsPoint;         // point in time the player contracted Dystentery
    public float DeathSecondsDuration;      // the duration it takes the player to die from Dystentery
}
