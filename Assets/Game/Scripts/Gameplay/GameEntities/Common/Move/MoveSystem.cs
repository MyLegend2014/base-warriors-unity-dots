using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
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

                MoveUseCase.CalculateMoveStep(movableAspect.MoveDirection,
                    movableAspect.MoveSpeed, SystemAPI.Time.DeltaTime, out float3 distance);
                movableAspect.CurrentPosition += distance;
            }
        }
    }
}