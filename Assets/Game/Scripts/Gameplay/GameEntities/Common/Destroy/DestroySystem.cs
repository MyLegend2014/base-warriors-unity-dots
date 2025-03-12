using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
    public partial struct DestroySystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityQuery query = SystemAPI.QueryBuilder().WithAll<DestroyRequest>().Build();
            
            if (query.CalculateEntityCount() == 0)
                return;
            
            NativeArray<Entity> destroyEntities = query.ToEntityArray(Allocator.Temp);
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);

            foreach (Entity destroyEntity in destroyEntities)
            {
                SystemAPI.SetComponentEnabled<DestroyRequest>(destroyEntity, false);
                entityCommandBuffer.DestroyEntity(destroyEntity);
            }
            
            entityCommandBuffer.Playback(state.EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}