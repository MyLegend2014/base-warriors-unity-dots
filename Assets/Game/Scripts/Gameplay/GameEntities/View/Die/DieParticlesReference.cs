using Game.Gameplay.Effects;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    public class DieParticlesReference : IComponentData
    {
        public ParticlesPoolBehaviour Reference;
    }
}