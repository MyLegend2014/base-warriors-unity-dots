using Unity.Entities;

namespace Game.Gameplay.GameEntities.Sounds
{
    public struct DieSound : IComponentData
    {
        public SoundType Type;
    }
}