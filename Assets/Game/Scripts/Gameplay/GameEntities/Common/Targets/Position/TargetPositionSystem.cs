using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    [UpdateAfter(typeof(TargetEntitySystem))]
    public partial struct TargetPositionSystem : ISystem
    {
        private float _updateDelay;
        private float _delayTimer;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _updateDelay = 0.5f;
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            _delayTimer -= SystemAPI.Time.DeltaTime;
            
            if (_delayTimer > 0)
                return;

            foreach (TargetPositionAspect aspect in SystemAPI.Query<TargetPositionAspect>())
            {
                if (aspect.IsExistsTarget() == false ||
                    SystemAPI.HasComponent<LocalTransform>(aspect.TargetEntity) == false)
                {
                    continue;
                }

                if (ColliderUseCase.TryGetClosestPosition(state.EntityManager, aspect.Self,
                        aspect.TargetEntity, out float3 closestPosition))
                {
                    aspect.TargetPosition = closestPosition;
                }
                else
                {
                    aspect.TargetPosition = SystemAPI
                        .GetComponentRO<LocalTransform>(aspect.TargetEntity).ValueRO.Position;
                }
            }

            _delayTimer = _updateDelay;
        }
    }
}