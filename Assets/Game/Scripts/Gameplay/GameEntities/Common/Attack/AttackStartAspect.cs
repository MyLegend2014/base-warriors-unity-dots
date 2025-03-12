using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct StartAttackAspect : IAspect
    {
        private readonly AttackCooldownAspect _attackCooldownAspect;
        private readonly ReachTargetPositionAspect _reachTargetPositionAspect;
        private readonly RefRO<TargetEntity> _targetEntity;

        public readonly Entity Self;
        
        public Entity TargetEntity => _targetEntity.ValueRO.Value;
        
        public bool IsReachedTarget => _reachTargetPositionAspect.IsReachedTarget;
        
        public bool IsExpiredAttackCooldown => _attackCooldownAspect.IsExpired;

        public void ResetAttackCooldown() => _attackCooldownAspect.ResetCooldown();
        
        public bool IsExistsTarget => TargetEntity != Entity.Null;
    }
}