using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct RotationAspect : IAspect
    {
        private readonly RefRO<MoveDirection> _moveDirection;
        private readonly RefRO<RotationSpeed> _rotationSpeed;
        private readonly RefRW<LocalTransform> _localTransform;
        [Optional] readonly RefRW<TargetPosition> _targetPosition;
        
        public float3 Position => _localTransform.ValueRO.Position;
        
        public float3 MoveDirection => _moveDirection.ValueRO.Value;
        
        public float RotationSpeed => _rotationSpeed.ValueRO.Value;

        public quaternion CurrentRotation
        {
            get => _localTransform.ValueRO.Rotation;
            set => _localTransform.ValueRW.Rotation = value;
        }
        
        public float3 TargetPosition => _targetPosition.ValueRO.Value;

        public bool IsExistsTargetPosition => _targetPosition.IsValid;
    }
}