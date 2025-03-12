using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    [BurstCompile]
    public static class ColliderUseCase
    {
        public static bool TryGetClosestPosition(in EntityManager entityManager, in Entity sourceEntity,
            in Entity targetEntity, out float3 closestPosition)
        {
            float3 sourceWorldPosition = TransformUseCase.CalculateWorldPosition(entityManager, sourceEntity);
            
            return TryGetClosestPosition(entityManager, sourceWorldPosition, targetEntity, out closestPosition);
        }
        
        public static bool TryGetClosestPosition(in EntityManager entityManager, in float3 sourceWorldPosition, 
            in Entity targetEntity, out float3 closestPosition)
        {
            closestPosition = default;
            
            PhysicsCollider targetCollider = entityManager.GetComponentData<PhysicsCollider>(targetEntity);
            LocalToWorld localToWorld = entityManager.GetComponentData<LocalToWorld>(targetEntity);
            
            var pointInput = new PointDistanceInput
            {
                Position = localToWorld.Value.InverseTransformPoint(sourceWorldPosition),
                MaxDistance = float.MaxValue,
                Filter = CollisionFilter.Default
            };

            if (targetCollider.Value.Value.CalculateDistance(pointInput, out DistanceHit closestHit))
            {
                closestPosition = localToWorld.Value.TransformPoint(closestHit.Position);
                
                return true;
            }

            return false;
        }
    }
}