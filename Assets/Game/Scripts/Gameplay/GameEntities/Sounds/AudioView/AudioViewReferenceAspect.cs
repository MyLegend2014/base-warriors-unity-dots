using Unity.Entities;

namespace Game.Gameplay.GameEntities.Sounds
{
    public readonly partial struct AudioViewReferenceAspect : IAspect
    {
        private readonly RefRO<AudioViewReference> _audioViewLink;

        public Entity AudioViewEntity => _audioViewLink.ValueRO.AudioView;
    }
}