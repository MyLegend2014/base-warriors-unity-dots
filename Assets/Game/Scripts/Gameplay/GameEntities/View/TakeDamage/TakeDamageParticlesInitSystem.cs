using Game.Gameplay.Effects;
using Unity.Collections;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.View
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    [UpdateAfter(typeof(ParticlesRegistryInitSystem))]
    public partial class TakeDamageParticlesInitSystem : SystemBase
    {
        private ParticlesRegistry _particlesRegistry;
        protected override void OnCreate()
        {
            base.OnCreate();
            RequireForUpdate<ParticlesRegistryReference>();
        }

        protected override void OnStartRunning()
        {
            EntityQuery query = new EntityQueryBuilder(Allocator.Temp)
                .WithAll<ParticlesRegistryReference>()
                .Build(this);

            _particlesRegistry = query.GetSingleton<ParticlesRegistryReference>().Value;
            InitializeParticles();
        }

        protected override void OnUpdate()
        {
        }

        private void InitializeParticles()
        {
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);

            foreach ((RefRO<TakeDamageParticleType> particleType, Entity entity) in
                     SystemAPI.Query<RefRO<TakeDamageParticleType>>()
                         .WithNone<TakeDamageParticlesReference>()
                         .WithEntityAccess())
            {
                if (_particlesRegistry.IsExistsParticlesPool(particleType.ValueRO.Value,
                        out ParticlesPoolBehaviour pool) == false)
                {
                    continue;
                }

                entityCommandBuffer.AddComponent(entity, new TakeDamageParticlesReference()
                { Reference = pool });
            }

            if (entityCommandBuffer.IsEmpty)
                return;

            entityCommandBuffer.Playback(EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}