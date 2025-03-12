using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public struct SpawnPoint : IComponentData
    {
        public Entity Value;
    }
}