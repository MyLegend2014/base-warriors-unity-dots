using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public partial struct LifetimeSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            
            foreach (LifeTimeAspect aspect in SystemAPI.Query<LifeTimeAspect>()
                         .WithNone<DestroyRequest>())
            {
                aspect.CurrentValue -= SystemAPI.Time.DeltaTime;

                if (aspect.IsAlive)
                    continue;

                entityCommandBuffer.AddComponent<DestroyRequest>(aspect.Self);
                entityCommandBuffer.AddComponent<DieEvent>(aspect.Self);
            }
            
            if (entityCommandBuffer.IsEmpty)
                return;
            
            entityCommandBuffer.Playback(state.EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}