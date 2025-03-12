using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    public partial struct SpawnSystem : ISystem
    {
        private float _defaultScale;
        private Entity _spawnerEntity;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<SpawnerTag>();
            _defaultScale = 1f;
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (_spawnerEntity == Entity.Null)
                _spawnerEntity = SystemAPI.GetSingleton<SpawnerTag>().Self;
            
            DynamicBuffer<SpawnRequest> spawnBuffer = SystemAPI.GetBuffer<SpawnRequest>(_spawnerEntity);
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            
            foreach (SpawnRequest request in spawnBuffer)
            {
                Entity entity = entityCommandBuffer.Instantiate(request.Prefab);
                
                entityCommandBuffer.AddComponent(entity, new LocalTransform()
                {
                    Position = request.Position,
                    Rotation = request.Rotation,
                    Scale = _defaultScale,
                });
            }
            
            if (entityCommandBuffer.IsEmpty)
                return;
            
            entityCommandBuffer.SetBuffer<SpawnRequest>(_spawnerEntity);
            entityCommandBuffer.Playback(state.EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}