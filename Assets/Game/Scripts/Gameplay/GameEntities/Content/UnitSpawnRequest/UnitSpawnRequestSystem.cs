using Game.Gameplay.GameEntities.Common;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Content
{
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
    [UpdateBefore(typeof(SpawnSystem))]
    public partial struct UnitSpawnRequestSystem : ISystem
    {
        private Entity _spawnerEntity;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<SpawnerTag>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (_spawnerEntity == Entity.Null)
                _spawnerEntity = SystemAPI.GetSingleton<SpawnerTag>().Self;
            
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            
            foreach (UnitSpawnAspect unitSpawnAspect in SystemAPI.Query<UnitSpawnAspect>())
            {
                Entity spawnPointEntity = unitSpawnAspect.GetRandomSpawnPoint();
                float3 spawnPosition = TransformUseCase.CalculateWorldPosition(state.EntityManager, spawnPointEntity);
                spawnPosition.y = 0;
                
                entityCommandBuffer.AppendToBuffer(_spawnerEntity, new SpawnRequest()
                {
                    Position = spawnPosition,
                    Rotation = quaternion.identity,
                    Prefab = unitSpawnAspect.GetRandomUnitPrefab(),
                });
                
                entityCommandBuffer.SetComponentEnabled<UnitSpawnRequest>(unitSpawnAspect.Self, false);
            }

            if (entityCommandBuffer.IsEmpty)
                return;
            
            entityCommandBuffer.Playback(state.EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}