using Unity.Entities;
using Unity.Jobs;

public class PlayerSystem : SystemBase
{
    protected override void OnCreate()  // optional
    {
        // stuff you want to happen on the main thread when the system starts.
    }

    protected override void OnDestroy() // optional
    {
        // stuff you want to happen on the main thread when the system terminates.
    }

    protected override void OnUpdate()   // required
    {
        // main thread operations here
        Entities
            .ForEach((ref PlayerComponent player) => 
            {
                // multi-threaded operations here
            })
            .WithName("PlayerJob")
            .ScheduleParallel();
        // potential more main thread operations here
    }
}
