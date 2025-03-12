using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public struct SpawnerTag : IComponentData
    {
        public Entity Self;
    }
}