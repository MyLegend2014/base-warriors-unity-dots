using Game.Gameplay.GameEntites.Common;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    [BurstCompile]
    public readonly struct TargetUseCase
    {
        [BurstCompile]
        public static bool TryFindNearestTarget(in SystemState state, in TeamColor currentUnitColor, 
            in float3 currentPosition, in EntityQuery otherEntitiesQuery, out Entity target)
        {
            target = Entity.Null;
            
            if (otherEntitiesQuery.CalculateEntityCount() == 0)
                return false;
            
            float nearestEntityDistance = math.INFINITY;

            using (NativeArray<Entity> otherEntities = otherEntitiesQuery.ToEntityArray(Allocator.Temp))
            {
                foreach (Entity entity in otherEntities)
                {
                    Team otherTeam = state.EntityManager.GetComponentData<Team>(entity);

                    if (otherTeam.Value == currentUnitColor)
                        continue;

                    LocalTransform otherLocalTransform = state.EntityManager.GetComponentData<LocalTransform>(entity);
                
                    float currentDistance = math.distancesq(currentPosition, otherLocalTransform.Position);
                
                    if (currentDistance < nearestEntityDistance)
                    {
                        nearestEntityDistance = currentDistance;
                        target = entity;
                    }
                }
            }
            
            return target != Entity.Null;
        }
        
        [BurstCompile]
        public static bool IsReachedTarget(in LocalTransform transform, in float3 targetPosition, 
            float stoppingDistance)
        {
            float distanceToTarget = MoveUseCase.CalculateDistance(transform.Position, targetPosition);

            return distanceToTarget <= stoppingDistance;
        }
    }
}