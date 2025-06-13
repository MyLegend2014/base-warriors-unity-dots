using Unity.Burst;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Common
{
    [BurstCompile]
    public static class RotationUseCase
    {
        [BurstCompile]
        public static void CalculateRotation(in float3 sourcePosition, in float3 targetPosition, out quaternion rotation)
        {
            float3 moveDirection = MoveDirectionUseCase.CalculateMoveDirection(sourcePosition, targetPosition);

            ClearRotationXZ(quaternion.LookRotationSafe(moveDirection, math.up()), out rotation);
        }

        [BurstCompile]
        public static void CalculateLerpRotation(in float3 sourcePosition, in float3 targetPosition,
            in quaternion currentRotation, float rotationSpeed, float deltaTime, out quaternion rotation)
        {
            float3 moveDirection = MoveDirectionUseCase.CalculateMoveDirection(sourcePosition, targetPosition);

            CalculateLerpRotation(moveDirection, currentRotation, rotationSpeed, deltaTime, out rotation);
        }

        [BurstCompile]
        public static void CalculateLerpRotation(in float3 moveDirection, in quaternion currentRotation,
            float rotationSpeed, float deltaTime, out quaternion rotation)
        {
            quaternion targetRotation = quaternion.LookRotationSafe(moveDirection, math.up());
            ClearRotationXZ(targetRotation, out var tempRotation);

            rotation = math.slerp(currentRotation, tempRotation, deltaTime * rotationSpeed);
        }

        [BurstCompile]
        private static void ClearRotationXZ(in quaternion rotation, out quaternion outRotation)
        {
            float3 euler = math.Euler(rotation);
            euler.x = 0f;
            euler.z = 0f;

            outRotation = quaternion.Euler(euler);
        }
    }
}