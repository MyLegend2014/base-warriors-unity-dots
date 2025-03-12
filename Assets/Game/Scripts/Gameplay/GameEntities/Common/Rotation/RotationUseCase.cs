using Unity.Burst;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Common
{
    [BurstCompile]
    public static class RotationUseCase
    {
        [BurstCompile]
        public static quaternion CalculateRotation(float3 sourcePosition, float3 targetPosition)
        {
            float3 moveDirection = MoveDirectionUseCase.CalculateMoveDirection(sourcePosition, targetPosition);
            
            return ClearRotationXZ(quaternion.LookRotationSafe(moveDirection, math.up()));
        }

        [BurstCompile]
        public static quaternion CalculateLerpRotation(float3 sourcePosition, float3 targetPosition, 
            quaternion currentRotation, float rotationSpeed, float deltaTime)
        {
            float3 moveDirection = MoveDirectionUseCase.CalculateMoveDirection(sourcePosition, targetPosition);
            
            return CalculateLerpRotation(moveDirection, currentRotation, rotationSpeed, deltaTime);
        }

        [BurstCompile]
        public static quaternion CalculateLerpRotation(float3 moveDirection, quaternion currentRotation, 
            float rotationSpeed, float deltaTime)
        {
            quaternion targetRotation = quaternion.LookRotationSafe(moveDirection, math.up());
            targetRotation = ClearRotationXZ(targetRotation);
                
            return math.slerp(currentRotation, targetRotation, deltaTime * rotationSpeed);
        }

        [BurstCompile]
        private static quaternion ClearRotationXZ(in quaternion rotation)
        {
            float3 euler = math.Euler(rotation);
            euler.x = 0f;
            euler.z = 0f;
            
            return quaternion.Euler(euler);
        }
    }
}