using Unity.Entities;

namespace Game.Gameplay.GameEntities.Sounds
{
    public struct TakeDamageSound : IComponentData
    {
        public SoundType Type;
    }
}