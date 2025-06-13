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
        public static void CalculateMoveStep(in float3 moveDirection, in float moveSpeed, in float deltaTime, out float3 distance)
        {
            distance = deltaTime * moveSpeed * moveDirection;
        }

        [BurstCompile]
        public static float CalculateDistance(in float3 position, in float3 target)
        {
            return math.distance(position, target);
        }
    }
}