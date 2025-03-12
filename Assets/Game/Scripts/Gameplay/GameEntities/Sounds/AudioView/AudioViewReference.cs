using Unity.Entities;

namespace Game.Gameplay.GameEntities.Sounds
{
    public struct AudioViewReference : IComponentData
    {
        public Entity AudioView;
    }
}