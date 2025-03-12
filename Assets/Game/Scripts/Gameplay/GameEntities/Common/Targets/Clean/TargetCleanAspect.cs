using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct TargetCleanAspect : IAspect
    { 
        private readonly RefRW<TargetEntity> _targetEntity;

        public readonly Entity Self;
        
        public Entity TargetEntity
        {
            get => _targetEntity.ValueRO.Value;
            set => _targetEntity.ValueRW.Value = value;
        }
    }
}