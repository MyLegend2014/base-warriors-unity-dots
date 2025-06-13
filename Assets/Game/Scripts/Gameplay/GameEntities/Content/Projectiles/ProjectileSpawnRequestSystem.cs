using Game.Gameplay.GameEntities.Common;
using Game.Gameplay.GameEntities.View;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.UniversalDelegates;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Content
{
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
    public partial struct ArrowSpawnRequestSystem : ISystem
    {
        private Entity _spawnerEntity;
        private uint _animationEventHash;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _animationEventHash = AnimatorUseCase.CreateAttackEventNameHash();
            state.RequireForUpdate<SpawnerTag>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (_spawnerEntity == Entity.Null)
                _spawnerEntity = SystemAPI.GetSingleton<SpawnerTag>().Self;
            
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            
            foreach (ProjectileSpawnRequestAspect aspect in SystemAPI.Query<ProjectileSpawnRequestAspect>())
            {
                if (aspect.IsExistAnimationEvent(state.EntityManager, _animationEventHash) == false ||
                    aspect.IsValidTarget() == false)
                {
                    continue;
                }
                
                LocalTransform targetTransform = SystemAPI.GetComponent<LocalTransform>(aspect.TargetEntity);
                float3 spawnPosition = aspect.CalculateSpawnPosition(state.EntityManager);
                RotationUseCase.CalculateRotation(spawnPosition, targetTransform.Position, out quaternion arrowRotation);
                
                entityCommandBuffer.AppendToBuffer(_spawnerEntity, new SpawnRequest()
                {
                    Prefab = aspect.ArrowPrefab,
                    Position = spawnPosition,
                    Rotation = arrowRotation,
                });
            }
            
            if (entityCommandBuffer.IsEmpty)
                return;
            
            entityCommandBuffer.Playback(state.EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}