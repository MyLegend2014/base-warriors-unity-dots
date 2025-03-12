using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    public static class TransformUseCase
    {
        [BurstCompile]
        public static float3 CalculateWorldPosition(in EntityManager entityManager, in Entity point)
        {
            LocalToWorld localToWorld = entityManager.GetComponentData<LocalToWorld>(point);

            return localToWorld.Value.TransformPoint(float3.zero);
        }
        
        [BurstCompile]
        public static float3 GetLocalPosition(in EntityManager entityManager, in Entity point)
        {
            LocalTransform localToWorld = entityManager.GetComponentData<LocalTransform>(point);

            return localToWorld.Position;
        }
    }
}