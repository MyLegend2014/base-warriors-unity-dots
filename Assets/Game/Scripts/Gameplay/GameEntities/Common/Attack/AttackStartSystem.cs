using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    [UpdateAfter(typeof(TargetPositionSystem))]
    public partial struct AttackStartSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (StartAttackAspect aspect in SystemAPI.Query<StartAttackAspect>().WithDisabled<AttackRequest>())
            {
                if (aspect.IsExistsTarget == false ||
                    SystemAPI.HasComponent<LocalTransform>(aspect.TargetEntity) == false ||
                    aspect.IsExpiredAttackCooldown == false ||
                    aspect.IsReachedTarget == false)
                {
                    continue;
                }

                SystemAPI.SetComponentEnabled<AttackRequest>(aspect.Self, true);
                aspect.ResetAttackCooldown();
            }
        }
    }
}