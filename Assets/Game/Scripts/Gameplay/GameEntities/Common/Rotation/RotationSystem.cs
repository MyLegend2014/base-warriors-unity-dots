using Unity.Burst;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    [UpdateAfter(typeof(MoveSystem))]
    public partial struct RotationSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (RotationAspect rotationAspect in SystemAPI.Query<RotationAspect>())
            {
                if (MoveDirectionUseCase.HasMoveDirection(rotationAspect.MoveDirection))
                {
                    rotationAspect.CurrentRotation = RotationUseCase.CalculateLerpRotation(rotationAspect.MoveDirection,
                        rotationAspect.CurrentRotation, rotationAspect.RotationSpeed, SystemAPI.Time.DeltaTime);
                }
                else if (rotationAspect.IsExistsTargetPosition)
                {
                    rotationAspect.CurrentRotation = RotationUseCase.CalculateLerpRotation(rotationAspect.Position,
                        rotationAspect.TargetPosition, rotationAspect.CurrentRotation, rotationAspect.RotationSpeed, 
                        SystemAPI.Time.DeltaTime);
                }
            }
        }
    }
}