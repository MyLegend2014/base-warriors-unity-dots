using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public partial struct TakeDamageSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            
            foreach (DamageableAspect damageableAspect in SystemAPI.Query<DamageableAspect>())
            {
                foreach (TakeDamageRequest takeDamageRequest in damageableAspect.TakeDamageRequestsBuffer)
                {
                    damageableAspect.Health -= takeDamageRequest.Damage;

                    entityCommandBuffer.SetComponentEnabled<TakeDamageEvent>(damageableAspect.Self, true);
                    
                    entityCommandBuffer.AddComponent(damageableAspect.Self, new TakeDamageEvent() 
                        { Position = takeDamageRequest.Position });
                }
                
                entityCommandBuffer.SetBuffer<TakeDamageRequest>(damageableAspect.Self);
            }

            if (entityCommandBuffer.IsEmpty)
                return;
            
            entityCommandBuffer.Playback(state.EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}