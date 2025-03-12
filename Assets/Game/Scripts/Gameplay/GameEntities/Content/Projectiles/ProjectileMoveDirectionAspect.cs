using Game.Gameplay.GameEntities.Common;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Content
{
    public readonly partial struct ProjectileMoveDirectionAspect : IAspect
    {
        private readonly ProjectileAspect _projectileAspect;
        private readonly RefRW<MoveDirection> _moveDirection;
        
        public quaternion Rotation => _projectileAspect.Rotation;

        public float3 MoveDirection
        {
            get => _moveDirection.ValueRO.Value;
            set => _moveDirection.ValueRW.Value = value;
        }

        public bool IsAlive => _projectileAspect.IsAlive;

        public bool IsExistsMoveDirection() => MoveDirectionUseCase.HasMoveDirection(MoveDirection);
        
        public void InitializeMoveDirection()
        {
            MoveDirection = MoveDirectionUseCase.CalculateMoveDirection(Rotation);
        }
    }
}