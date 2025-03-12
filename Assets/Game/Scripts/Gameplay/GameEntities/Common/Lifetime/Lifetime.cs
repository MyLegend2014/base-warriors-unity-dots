using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public struct Lifetime : IComponentData
    {
        public float MaxValue;
        
        public float CurrentValue;
    }
}