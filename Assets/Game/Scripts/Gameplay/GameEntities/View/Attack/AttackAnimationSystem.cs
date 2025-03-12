using Game.Gameplay.Core;
using Game.Gameplay.GameEntities.Common;
using Rukhanka;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.View
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial struct AttackAnimationSystem : ISystem
    {
        private const string Attack = nameof(Attack);
        private FastAnimatorParameter _attackParameter;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _attackParameter = new FastAnimatorParameter(Attack);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (AttackAnimationAspect aspect in SystemAPI.Query<AttackAnimationAspect>())
            {
                AnimatorParametersAspect animatorParametersAspect =
                    SystemAPI.GetAspect<AnimatorParametersAspect>(aspect.AnimatorEntity);
                
                if (SystemAPI.HasComponent<LocalTransform>(aspect.TargetEntity) == false ||
                    aspect.IsExistsTarget == false || 
                    SystemAPI.GetComponentRO<Health>(aspect.TargetEntity).ValueRO.Value <= 0)
                {
                    ResetAttack(ref state, animatorParametersAspect, aspect);

                    continue;
                }

                if (aspect.IsReachedTarget == false)
                {
                    ResetAttack(ref state, animatorParametersAspect, aspect);

                    continue;
                }
                
                animatorParametersAspect.SetTrigger(_attackParameter);
                DisableAttackRequest(ref state, aspect);
            }
        }
        
        [BurstCompile]
        private void ResetAttack(ref SystemState state, 
            in AnimatorParametersAspect animatorParametersAspect, AttackAnimationAspect attackerAspect)
        {
            animatorParametersAspect.ResetTrigger(_attackParameter);
            DisableAttackRequest(ref state, attackerAspect);
        }
        
        [BurstCompile]
        private void DisableAttackRequest(ref SystemState state, in AttackAnimationAspect attackerAspect)
        {
            SystemAPI.SetComponentEnabled<AttackRequest>(attackerAspect.Self, false);
        }
    }
}