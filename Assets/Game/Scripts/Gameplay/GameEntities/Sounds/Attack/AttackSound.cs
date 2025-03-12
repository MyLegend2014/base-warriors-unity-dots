using Unity.Entities;

namespace Game.Gameplay.GameEntities.Sounds
{
    public struct AttackSound : IComponentData
    {
        public SoundType Type;
    }
}