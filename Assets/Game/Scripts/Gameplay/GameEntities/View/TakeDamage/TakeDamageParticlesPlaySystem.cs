using Game.Gameplay.GameEntities.Common;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    [UpdateBefore(typeof(EventsCleanSystem))]
    public partial class TakeDamageParticlesPlaySystem : SystemBase
    {
        protected override void OnUpdate()
        {
            foreach ((TakeDamageParticlesReference particlesReference, 
                         RefRO<TakeDamageEvent> takeDamageEvent) in 
                     SystemAPI.Query<TakeDamageParticlesReference, RefRO<TakeDamageEvent>>()
                         .WithAll<TakeDamageEvent>())
            {
                particlesReference.Reference.Play(takeDamageEvent.ValueRO.Position);
            }
        }
    }
}