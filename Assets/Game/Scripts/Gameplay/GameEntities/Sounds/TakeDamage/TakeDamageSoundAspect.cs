using Game.Gameplay.GameEntities.Common;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Sounds
{
    public readonly partial struct TakeDamageSoundAspect : IAspect
    {
        private readonly RefRO<TakeDamageEvent> _takeDamageEvent;
        private readonly RefRO<AudioViewReference> _audioViewReference;

        public Entity AudioViewEntity => _audioViewReference.ValueRO.AudioView;
    }
}