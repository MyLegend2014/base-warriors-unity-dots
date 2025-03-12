using Game.Gameplay.GameEntities.Common;
using Game.Gameplay.GameEntities.View;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Content
{
    public readonly partial struct ProjectileSpawnRequestAspect : IAspect
    {
        private readonly RefRO<ProjectileAttackerTag> _projectileAttackerTag;
        private readonly RefRO<ProjectilePrefab> _arrowPrefab;
        private readonly RefRO<SpawnPoint> _spawnPoint;
        private readonly AnimatorReferenceAspect _animatorReferenceAspect;
        private readonly ReachTargetEntityAspect _reachTargetEntityAspect;
        
        public Entity ArrowPrefab => _arrowPrefab.ValueRO.Value;
        
        public Entity TargetEntity => _reachTargetEntityAspect.TargetEntity;
        
        public Entity SpawnPoint => _spawnPoint.ValueRO.Value;

        public bool IsExistAnimationEvent(in EntityManager entityManager, in uint animationEventHash) =>
            _animatorReferenceAspect.IsExistAnimationEvent(entityManager, animationEventHash);
        
        public bool IsValidTarget() => TargetEntity != Entity.Null;

        public float3 CalculateSpawnPosition(in EntityManager entityManager)
        {
            return TransformUseCase.CalculateWorldPosition(entityManager, SpawnPoint);
        }
    }
}