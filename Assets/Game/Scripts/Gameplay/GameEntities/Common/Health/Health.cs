using Unity.Entities;

namespace Game.Gameplay.Core
{
    public struct Health : IComponentData
    {
        public int MaxValue;

        public int Value;
    }
}