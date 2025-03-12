using Game.Gameplay.GameEntities.Common;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    [UpdateBefore(typeof(EventsCleanSystem))]
    public partial class DieParticlesPlaySystem : SystemBase
    {
        protected override void OnUpdate()
        {
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer();
            
            foreach ((DieParticlesReference particlesReference, 
                         Entity entity) in 
                     SystemAPI.Query<DieParticlesReference>()
                         .WithAll<DieEvent>()
                         .WithEntityAccess())
            {
                particlesReference.Reference.Play(TransformUseCase.CalculateWorldPosition(EntityManager, entity));
            }
        }
    }
}