using Game.Gameplay.Effects;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    public sealed class TakeDamageParticlesReference : IComponentData
    {
        public ParticlesPoolBehaviour Reference;
    }
}