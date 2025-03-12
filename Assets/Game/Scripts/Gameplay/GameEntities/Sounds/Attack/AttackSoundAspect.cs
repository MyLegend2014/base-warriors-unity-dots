using Game.Gameplay.GameEntities.View;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Sounds
{
    public readonly partial struct AttackSoundAspect : IAspect
    {
        private readonly AudioViewReferenceAspect _audioViewReferenceAspect;
        private readonly AnimatorReferenceAspect _animatorReferenceAspect;

        public Entity AudioViewEntity => _audioViewReferenceAspect.AudioViewEntity;

        public bool IsExistsAnimationEvent(in EntityManager entityManager, in uint animationEventHash) =>
            _animatorReferenceAspect.IsExistAnimationEvent(entityManager, animationEventHash);
    }
}