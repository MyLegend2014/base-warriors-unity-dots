using Game.Gameplay.GameEntities.View;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
    public partial struct InstantDamageRequestSystem : ISystem
    {
        private uint _animationEventHash;
        
        public void OnCreate(ref SystemState state)
        {
            _animationEventHash = AnimatorUseCase.CreateAttackEventNameHash();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer entityCommandBuffer = new(Allocator.Temp);
            
            foreach (InstantDamageAspect aspect in SystemAPI.Query<InstantDamageAspect>())
            {
                if (aspect.IsReachedTarget == false ||
                    aspect.IsExistAnimationEvent(state.EntityManager, _animationEventHash) == false)
                {
                    continue;
                }

                entityCommandBuffer.AppendToBuffer(aspect.TargetEntity, 
                    new TakeDamageRequest { Damage = aspect.Damage, Position = aspect.TargetPosition });
            }
            
            entityCommandBuffer.Playback(state.EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}