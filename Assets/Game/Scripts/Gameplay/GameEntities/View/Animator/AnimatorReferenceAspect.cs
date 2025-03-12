using Rukhanka;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    public readonly partial struct AnimatorReferenceAspect : IAspect
    {
        private readonly RefRO<AnimatorEntityReference> _animatorEntityReference;
        
        public Entity AnimatorEntity => _animatorEntityReference.ValueRO.AnimatorEntity;
        
        public bool IsExistAnimationEvent(in EntityManager entityManager, in uint animationEventHash)
        {
            if (TryGetAnimationEventsBuffer(entityManager,
                    out DynamicBuffer<AnimationEventComponent> eventsBuffer) == false)
            {
                return false;
            }
            
            foreach (AnimationEventComponent animationEvent in eventsBuffer)
            {
                if (animationEvent.nameHash == animationEventHash)
                    return true;
            }

            return false;
        }

        private bool TryGetAnimationEventsBuffer(in EntityManager entityManager, 
            out DynamicBuffer<AnimationEventComponent> buffer)
        {
            buffer = default;

            if (entityManager.IsComponentEnabled<AnimationEventComponent>(AnimatorEntity) == false)
                return false;
            
            buffer = entityManager.GetBuffer<AnimationEventComponent>(AnimatorEntity);

            return true;
        }
    }
}