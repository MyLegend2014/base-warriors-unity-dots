using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct TargetDistanceAspect : IAspect
    {
        private readonly RefRO<LocalTransform> _localTransform;
        private readonly RefRO<TargetEntity> _targetEntity;
        private readonly RefRO<TargetPosition> _targetPosition;
        private readonly RefRW<TargetDistance> _targetDistance;
        
        public Entity TargetEntity => _targetEntity.ValueRO.Value;
        
        public float3 SelfPosition => _localTransform.ValueRO.Position;
        
        public float3 TargetPosition => _targetPosition.ValueRO.Value;

        public float TargetDistance
        {
            get => _targetDistance.ValueRO.Value;
            set => _targetDistance.ValueRW.Value = value;
        }
        
        public bool IsExistsTarget() => _targetEntity.IsValid && _targetEntity.ValueRO.Value != Entity.Null;
    }
}