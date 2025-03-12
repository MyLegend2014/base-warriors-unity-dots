using Game.Gameplay.Effects;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.View
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class ParticlesRegistryInitSystem : SystemBase
    {
        private ParticlesRegistry _particlesRegistry;

        protected override void OnStartRunning()
        {
            CreateParticlesRegistry();
        }
        
        protected override void OnUpdate()
        {
        }

        protected override void OnDestroy()
        {
            Object.Destroy(_particlesRegistry);
        }

        private void CreateParticlesRegistry()
        {
            EntityQuery query = new EntityQueryBuilder(Allocator.Temp)
                .WithAll<ParticlesRegistryPrefab>()
                .WithNone<ParticlesRegistryReference>()
                .Build(this);

            if (query.CalculateEntityCount() == 0)
                return;
            
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);

            ParticlesRegistryPrefab particlesRegistryPrefab = query.GetSingleton<ParticlesRegistryPrefab>();
            _particlesRegistry = Object.Instantiate(particlesRegistryPrefab.Value);
            
            entityCommandBuffer.AddComponentObject(query,
                new ParticlesRegistryReference() { Value = _particlesRegistry });
            
            entityCommandBuffer.Playback(EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}