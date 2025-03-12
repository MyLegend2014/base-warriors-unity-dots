using Unity.Entities;

namespace Game.Gameplay.Core
{
    public readonly partial struct HealthAspect : IAspect
    {
        private readonly RefRO<Health> _health;

        public readonly Entity Self;

        public int CurrentHealth => _health.ValueRO.Value;
    }
}