using Game.Gameplay.GameEntities.Common;
using Rukhanka;
using Unity.Burst;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial struct TakeDamageAnimationSystem : ISystem
    {
        private FastAnimatorParameter _takeDamageParameter;
        private const string TakeDamageTriggerName = "Take Damage";
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _takeDamageParameter = new FastAnimatorParameter(TakeDamageTriggerName);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (AnimatorReferenceAspect aspect in SystemAPI.Query<AnimatorReferenceAspect>().WithAll<TakeDamageEvent>())
            {
                AnimatorParametersAspect animatorParametersAspect =
                    SystemAPI.GetAspect<AnimatorParametersAspect>(aspect.AnimatorEntity);
                
                animatorParametersAspect.SetTrigger(_takeDamageParameter);
            }
        }
    }
}