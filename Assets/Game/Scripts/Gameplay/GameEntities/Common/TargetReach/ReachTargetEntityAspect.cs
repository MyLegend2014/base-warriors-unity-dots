using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct ReachTargetEntityAspect : IAspect
    {
        private readonly RefRO<TargetEntity> _targetEntity;
        private readonly ReachTargetPositionAspect _reachTargetPositionAspect;

        public Entity TargetEntity => _targetEntity.ValueRO.Value;
        
        public bool IsReachedTarget => TargetEntity != Entity.Null && _reachTargetPositionAspect.IsReachedTarget;
    }
}