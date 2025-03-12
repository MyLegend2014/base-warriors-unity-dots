using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct LifeTimeAspect : IAspect
    {
        private readonly RefRW<Lifetime> _lifetime;

        public readonly Entity Self;

        public float CurrentValue
        {
            get => _lifetime.ValueRO.CurrentValue;
            set => _lifetime.ValueRW.CurrentValue = value;
        }
        
        public bool IsAlive => CurrentValue > 0;
    }
}