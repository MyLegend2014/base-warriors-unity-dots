using Game.Gameplay.GameEntites.Common;
using Game.Gameplay.GameEntities.Common;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Content
{
    public readonly partial struct ProjectileAspect : IAspect
    {
        private readonly RefRO<ProjectileTag> _tag;
        private readonly RefRO<Team> _team;
        private readonly RefRO<Damage> _damage;
        private readonly RefRO<Lifetime> _lifetime;
        private readonly RefRO<LocalTransform> _localTransform;
        private readonly RefRO<PhysicsCollider> _collider;

        public readonly Entity Self;
        
        public TeamColor TeamColor => _team.ValueRO.Value;
        
        public float3 Position => _localTransform.ValueRO.Position;
        
        public quaternion Rotation => _localTransform.ValueRO.Rotation;
        
        public PhysicsCollider Collider => _collider.ValueRO;
        
        public int Damage => _damage.ValueRO.Value;

        public bool IsAlive => _lifetime.ValueRO.CurrentValue > 0;
    }
}