using Game.Gameplay.GameEntities.View;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Sounds
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    [UpdateBefore(typeof(SoundPlaySystem))]
    [UpdateAfter(typeof(AttackAnimationSystem))]
    public partial class AttackSoundRequestSystem : SystemBase
    {
        private uint _attackAnimationEventHash;
        
        protected override void OnCreate()
        {
            _attackAnimationEventHash = AnimatorUseCase.CreateAttackEventNameHash();
        }

        protected override void OnUpdate()
        {
            EntityCommandBuffer entityCommandBuffer = new(Allocator.Temp);
            
            foreach (AttackSoundAspect aspect in SystemAPI.Query<AttackSoundAspect>())
            {
                if (aspect.IsExistsAnimationEvent(EntityManager, _attackAnimationEventHash) == false)
                    continue;

                if (SystemAPI.HasComponent<AttackSound>(aspect.AudioViewEntity) == false)
                    continue;

                AttackSound attackSound = SystemAPI.GetComponent<AttackSound>(aspect.AudioViewEntity);
                
                entityCommandBuffer.AppendToBuffer(aspect.AudioViewEntity, new SoundPlayRequest() 
                    { AudioView = aspect.AudioViewEntity, SoundType = attackSound.Type});
                
                EntityManager.SetComponentEnabled<SoundPlayRequest>(aspect.AudioViewEntity, true);
            }

            if (entityCommandBuffer.IsEmpty)
                return;
            
            entityCommandBuffer.Playback(EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}