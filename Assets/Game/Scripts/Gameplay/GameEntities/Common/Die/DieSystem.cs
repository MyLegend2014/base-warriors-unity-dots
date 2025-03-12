using Game.Gameplay.Core;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    [UpdateAfter(typeof(TakeDamageSystem))]
    public partial struct DieSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            
            foreach (HealthAspect healthAspect in SystemAPI.Query<HealthAspect>())
            {
                if (healthAspect.CurrentHealth > 0)
                    continue;
                
                entityCommandBuffer.AddComponent<DestroyRequest>(healthAspect.Self);
                entityCommandBuffer.SetComponentEnabled<DieEvent>(healthAspect.Self, true);
            }

            if (entityCommandBuffer.IsEmpty)
                return;
            
            entityCommandBuffer.Playback(state.EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}