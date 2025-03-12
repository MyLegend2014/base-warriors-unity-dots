using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct MovableAspect : IAspect
    {
        private readonly RefRO<MoveDirection> _moveDirection;
        private readonly RefRO<MoveSpeed> _moveSpeed;
        private readonly RefRW<LocalTransform> _localTransform;

        public readonly Entity Self;
        
        public float3 MoveDirection => _moveDirection.ValueRO.Value;
        
        public float MoveSpeed => _moveSpeed.ValueRO.Value;

        public float3 CurrentPosition
        {
            get => _localTransform.ValueRO.Position;
            set => _localTransform.ValueRW.Position = value;
        }

        public bool IsExistsSelfTransform() => _localTransform.IsValid;
    }
}