using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    [UpdateAfter(typeof(TargetMoveDirectionSystem))]
    public partial struct MoveSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (MovableAspect movableAspect in SystemAPI.Query<MovableAspect>())
            {
                if (movableAspect.IsExistsSelfTransform() == false || 
                    MoveDirectionUseCase.HasMoveDirection(movableAspect) == false)
                {
                    continue;
                }

                movableAspect.CurrentPosition += MoveUseCase.CalculateMoveStep(movableAspect.MoveDirection,
                    movableAspect.MoveSpeed, SystemAPI.Time.DeltaTime);
            }
        }
    }
}