using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct AttackCooldownAspect : IAspect
    {
        private readonly RefRW<AttackCooldown> _attackCooldown;

        public float CurrentValue
        {
            get => _attackCooldown.ValueRO.CurrentValue;
            set => _attackCooldown.ValueRW.CurrentValue = value;
        }
        
        public bool IsExpired => CurrentValue < 0;

        public void ResetCooldown() => CurrentValue = MaxValue;
        
        private float MaxValue => _attackCooldown.ValueRO.MaxValue;
    }
}