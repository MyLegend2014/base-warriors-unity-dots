using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public struct AttackCooldown : IComponentData
    {
        public float MaxValue;
        
        public float CurrentValue;
    }
}