using Unity.Collections;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Sounds
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    [UpdateBefore(typeof(SoundPlaySystem))]
    public partial class TakeDamageSoundRequestSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            EntityCommandBuffer entityCommandBuffer = new(Allocator.Temp);

            foreach (TakeDamageSoundAspect takeDamageAudioAspect in SystemAPI.Query<TakeDamageSoundAspect>())
            {
                if (SystemAPI.HasComponent<TakeDamageSound>(takeDamageAudioAspect.AudioViewEntity) == false)
                    continue;

                TakeDamageSound sound = SystemAPI.GetComponent<TakeDamageSound>(takeDamageAudioAspect.AudioViewEntity);
                
                entityCommandBuffer.AppendToBuffer(takeDamageAudioAspect.AudioViewEntity, new SoundPlayRequest() 
                    { AudioView = takeDamageAudioAspect.AudioViewEntity, SoundType = sound.Type});
                
                EntityManager.SetComponentEnabled<SoundPlayRequest>(takeDamageAudioAspect.AudioViewEntity, true);
            }

            if (entityCommandBuffer.IsEmpty)
                return;
            
            entityCommandBuffer.Playback(EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}