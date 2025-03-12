using Game.Gameplay.GameEntites.Common;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct TargetEntityAspect : IAspect
    {
        private readonly RefRO<Team> _team;
        private readonly RefRW<TargetEntity> _targetEntity;
        private readonly RefRO<LocalTransform> _localTransform;
        
        public readonly Entity Self;
        
        public TeamColor Team => _team.ValueRO.Value;
        
        public float3 SelfPosition => _localTransform.ValueRO.Position;

        public Entity TargetEntity
        {
            get => _targetEntity.ValueRO.Value;
            set => _targetEntity.ValueRW.Value = value;
        }
        
        public bool IsExistsTarget() => _targetEntity.ValueRO.Value != Entity.Null;
    }
}