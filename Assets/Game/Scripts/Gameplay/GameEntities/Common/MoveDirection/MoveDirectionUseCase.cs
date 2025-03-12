using Unity.Burst;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Common
{
    public static class MoveDirectionUseCase
    {
        [BurstCompile]
        public static bool HasMoveDirection(in MovableAspect aspect) => HasMoveDirection(aspect.MoveDirection);
        
        [BurstCompile]
        public static bool HasMoveDirection(float3 moveDirection) => math.any(moveDirection != float3.zero);
        
        [BurstCompile]
        public static float3 CalculateMoveDirection(in float3 position, in float3 target)
        {
            return math.normalize(target - position);
        }
        
        [BurstCompile]
        public static float3 CalculateMoveDirection(in quaternion rotation) => math.forward(rotation);
    }
}