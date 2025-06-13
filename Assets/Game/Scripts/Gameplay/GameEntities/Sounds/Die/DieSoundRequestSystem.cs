using Unity.Collections;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Sounds
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    [UpdateBefore(typeof(SoundPlaySystem))]
    public partial class DieSoundRequestSystem : SystemBase
    {
        private Entity _audioView;
        protected override void OnCreate()
        {
            RequireForUpdate<GlobalAudioView>();
        }

        protected override void OnStartRunning()
        {
            _audioView = SystemAPI.GetSingleton<GlobalAudioView>().ViewEntity;
        }
        
        protected override void OnUpdate()
        {
            EntityCommandBuffer entityCommandBuffer = new(Allocator.Temp);

            foreach (DieSoundAspect dieSoundAspect in SystemAPI.Query<DieSoundAspect>())
            {
                if (SystemAPI.HasComponent<DieSound>(dieSoundAspect.AudioViewEntity) == false)
                    continue;

                DieSound sound = SystemAPI.GetComponent<DieSound>(dieSoundAspect.AudioViewEntity);
                
                entityCommandBuffer.AppendToBuffer(dieSoundAspect.AudioViewEntity, new SoundPlayRequest() 
                    { AudioView = _audioView, SoundType = sound.Type});
                
                EntityManager.SetComponentEnabled<SoundPlayRequest>(dieSoundAspect.AudioViewEntity, true);
            }

            if (entityCommandBuffer.IsEmpty)
                return;
            
            entityCommandBuffer.Playback(EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}