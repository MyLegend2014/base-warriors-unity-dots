using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public struct SpawnPointBuffer : IBufferElementData
    {
        public Entity Value;
    }
}