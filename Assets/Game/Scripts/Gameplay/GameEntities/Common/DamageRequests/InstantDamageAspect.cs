using Game.Gameplay.GameEntities.View;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct InstantDamageAspect : IAspect
    {
        private readonly RefRO<InstantAttackTag> _instantAttackTag;
        private readonly AnimatorReferenceAspect _animatorReferenceAspect;
        private readonly ReachTargetEntityAspect _reachTargetEntityAspect;
        private readonly RefRO<Damage> _damage;
        private readonly RefRO<TargetPosition> _targetPosition;
        
        public Entity TargetEntity => _reachTargetEntityAspect.TargetEntity;

        public bool IsReachedTarget => _reachTargetEntityAspect.IsReachedTarget;

        public int Damage => _damage.ValueRO.Value;
        
        public float3 TargetPosition => _targetPosition.ValueRO.Value;

        public bool IsExistAnimationEvent(in EntityManager entityManager, in uint animationEventHash) =>
            _animatorReferenceAspect.IsExistAnimationEvent(entityManager, animationEventHash);
    }
}