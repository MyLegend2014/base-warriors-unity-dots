using Game.Gameplay.Core;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct DamageableAspect : IAspect
    {
        private readonly RefRW<Health> _health;

        public readonly Entity Self;
        
        public readonly DynamicBuffer<TakeDamageRequest> TakeDamageRequestsBuffer;

        public int Health
        {
            get => _health.ValueRO.Value;
            
            set
            {
                _health.ValueRW.Value = value;
                _health.ValueRW.Value = math.max(0, _health.ValueRO.Value);
            }
        }
    }
}