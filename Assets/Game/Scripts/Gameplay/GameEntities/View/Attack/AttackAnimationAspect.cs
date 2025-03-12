using Game.Gameplay.GameEntities.Common;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    public readonly partial struct AttackAnimationAspect : IAspect
    {
        private readonly RefRO<AttackRequest> _attackRequest;
        private readonly AnimatorReferenceAspect _animatorReferenceAspect;
        private readonly RefRO<TargetEntity> _taretEntity;
        private readonly ReachTargetPositionAspect _reachTargetPositionAspect;

        public readonly Entity Self;
        
        public Entity AnimatorEntity => _animatorReferenceAspect.AnimatorEntity;
        
        public Entity TargetEntity => _taretEntity.ValueRO.Value;
        
        public bool IsExistsTarget => TargetEntity != Entity.Null;

        public bool IsReachedTarget => _reachTargetPositionAspect.IsReachedTarget;
    }
}