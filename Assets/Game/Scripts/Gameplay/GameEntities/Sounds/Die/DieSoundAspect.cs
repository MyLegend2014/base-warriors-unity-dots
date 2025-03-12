using Game.Gameplay.GameEntities.Common;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Sounds
{
    public readonly partial struct DieSoundAspect : IAspect
    {
        private readonly RefRO<DieEvent> _dieEvent;
        private readonly AudioViewReferenceAspect _audioViewReferenceAspect;

        public Entity AudioViewEntity => _audioViewReferenceAspect.AudioViewEntity;
    }
}