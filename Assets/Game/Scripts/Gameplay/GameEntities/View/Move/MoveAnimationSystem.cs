using Game.Gameplay.GameEntities.Common;
using Rukhanka;
using Unity.Burst;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial struct MoveAnimationSystem : ISystem
    {
        private const string Speed = nameof(Speed);
        private const int SpeedMaxValue = 1;
        private FastAnimatorParameter _moveSpeedParameter;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _moveSpeedParameter = new FastAnimatorParameter(Speed);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (MoveAnimationAspect aspect in SystemAPI.Query<MoveAnimationAspect>())
            {
                AnimatorParametersAspect animatorParametersAspect =
                    SystemAPI.GetAspect<AnimatorParametersAspect>(aspect.AnimatorEntity);

                if (MoveDirectionUseCase.HasMoveDirection(aspect.MoveDirection))
                    animatorParametersAspect.SetParameterValue(_moveSpeedParameter, SpeedMaxValue);
                else
                    animatorParametersAspect.SetParameterValue(_moveSpeedParameter, 0);
            }
        }
    }
}