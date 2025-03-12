using Game.Gameplay.Effects;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    public class ParticlesRegistryReference : IComponentData
    {
        public ParticlesRegistry Value;
    }
}