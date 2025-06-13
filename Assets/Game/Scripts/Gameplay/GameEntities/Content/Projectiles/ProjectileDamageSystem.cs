using Game.Gameplay.GameEntities.Common;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Physics;

namespace Game.Gameplay.GameEntities.Content
{
    public partial struct ProjectileDamageSystem : ISystem
    {
        private float _delayTimer;
        private float _updateDelay;

        public void OnCreate(ref SystemState state)
        {
            _updateDelay = 0.05f;
            state.RequireForUpdate<PhysicsWorldSingleton>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            _delayTimer -= SystemAPI.Time.DeltaTime;
            
            if (_delayTimer > 0)
                return;
            
            PhysicsWorldSingleton physicsWorld = SystemAPI.GetSingleton<PhysicsWorldSingleton>();
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            
            foreach (ProjectileAspect projectile in SystemAPI.Query<ProjectileAspect>())
            {
                NativeList<DistanceHit> hits = new NativeList<DistanceHit>(Allocator.Temp);
                BoxOverlapInput input = ProjectileUseCase.CalculateBoxOverlapInput(state.EntityManager, projectile);

                if (OverlapUseCase.IsExistsOverlapHits(physicsWorld, input, ref hits) == false)
                {
                    hits.Dispose();
                    
                    continue;
                }

                foreach (DistanceHit hit in hits)
                {
                    if (SystemAPI.HasComponent<UnitTag>(hit.Entity) == false && 
                        SystemAPI.HasComponent<BuildTag>(hit.Entity) == false)
                    {
                        continue;
                    }
                    
                    RefRO<Team> targetTeam = SystemAPI.GetComponentRO<Team>(hit.Entity);

                    if (targetTeam.ValueRO.Value == projectile.TeamColor)
                        continue;
                    
                    entityCommandBuffer.AppendToBuffer(hit.Entity, 
                        new TakeDamageRequest { Damage = projectile.Damage, Position = hit.Position });
                    
                    entityCommandBuffer.AddComponent<DestroyRequest>(projectile.Self);
                }
                
                hits.Dispose();
            }

            if (entityCommandBuffer.IsEmpty == false)
            {
                entityCommandBuffer.Playback(state.EntityManager);
                entityCommandBuffer.Dispose();
            }

            _delayTimer = _updateDelay;
        }
    }
}