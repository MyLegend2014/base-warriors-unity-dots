using Game.Gameplay.Effects;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    public struct TakeDamageParticleType : IComponentData
    {
        public ParticleType Value;
    }
}