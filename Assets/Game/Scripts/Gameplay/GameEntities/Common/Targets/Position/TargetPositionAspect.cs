using Game.Gameplay.GameEntites.Common;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct TargetPositionAspect : IAspect
    { 
        private readonly RefRO<TargetEntity> _targetEntity;
        private readonly RefRW<TargetPosition> _targetPosition;

        public readonly Entity Self;

        public Entity TargetEntity => _targetEntity.ValueRO.Value;
        
        public float3 TargetPosition
        {
            get => _targetPosition.ValueRO.Value;
            set => _targetPosition.ValueRW.Value = value;
        }
        
        public bool IsExistsTarget() => _targetEntity.IsValid && _targetEntity.ValueRO.Value != Entity.Null;
    }
}