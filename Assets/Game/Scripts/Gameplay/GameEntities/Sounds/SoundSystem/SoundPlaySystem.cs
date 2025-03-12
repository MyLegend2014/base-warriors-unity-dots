using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Sounds
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial class SoundPlaySystem : SystemBase
    {
        private SoundLibrary _soundLibrary;

        protected override void OnStartRunning()
        {
           EntityQuery query =new EntityQueryBuilder(Allocator.Temp)
               .WithAll<SoundLibrary>()
               .Build(EntityManager);

           _soundLibrary = query.GetSingleton<SoundLibrary>();
        }
        
        protected override void OnUpdate()
        {
            EntityQuery query = new EntityQueryBuilder(Allocator.Temp)
                .WithAll<SoundPlayRequest>()
                .Build(EntityManager);

            foreach (Entity entity in query.ToEntityArray(Allocator.Temp))
                TryPlaySounds(entity);
        }
        
        private bool TryPlaySounds(in Entity entity)
        {
            DynamicBuffer<SoundPlayRequest> audioPlayRequestsBuffer = SystemAPI.GetBuffer<SoundPlayRequest>(entity);
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);

            if (audioPlayRequestsBuffer.IsEmpty == false)
            {
                foreach (SoundPlayRequest audioPlayRequest in audioPlayRequestsBuffer)
                {
                    AudioSource audioSource = EntityManager
                        .GetComponentObject<AudioSource>(audioPlayRequest.AudioView);

                    if (audioSource == null)
                        continue;
                
                    if (_soundLibrary.Value.IsExistsAudio(audioPlayRequest.SoundType, out AudioClip clip) == false)
                        continue;
                
                    audioSource.PlayOneShot(clip);
                }

                entityCommandBuffer.SetBuffer<SoundPlayRequest>(entity);
            }

            if (entityCommandBuffer.IsEmpty == false)
            {
                entityCommandBuffer.Playback(EntityManager);
                entityCommandBuffer.Dispose();
            }
            
            EntityManager.SetComponentEnabled<SoundPlayRequest>(entity, false);

            return true;
        }
    }
}