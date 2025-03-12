using Game.Gameplay.GameEntities.Content;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    [BurstCompile]
    public readonly struct MoveUseCase
    {
        [BurstCompile]
        public static float3 CalculateMoveStep(in float3 moveDirection, in float moveSpeed, in float deltaTime)
        {
            return moveDirection * moveSpeed * deltaTime;
        }

        [BurstCompile]
        public static float CalculateDistance(in float3 position, in float3 target)
        {
            return math.distance(position, target);
        }
    }
}