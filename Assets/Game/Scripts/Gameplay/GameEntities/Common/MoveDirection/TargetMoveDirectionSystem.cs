using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Common
{
    [UpdateAfter(typeof(TargetPositionSystem))]
    public partial struct TargetMoveDirectionSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (targetMoveDirectionAspect movable in SystemAPI.Query<targetMoveDirectionAspect>())
            {
                if ((movable.IsExistsStoppingDistance() && movable.IsExistTargetDistance() 
                                                        && movable.TargetDistance <= movable.StoppingDistance))
                {
                    movable.MoveDirection = float3.zero;
                    
                    continue;
                }
                
                float3 direction = MoveDirectionUseCase.CalculateMoveDirection(movable.SelfPosition, movable.TargetPosition);
                direction.y = 0;
                
                movable.MoveDirection = direction;
            }
        }
    }
}