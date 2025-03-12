using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    public struct AnimatorEntityReference : IComponentData
    {
        public Entity AnimatorEntity;
    }
}