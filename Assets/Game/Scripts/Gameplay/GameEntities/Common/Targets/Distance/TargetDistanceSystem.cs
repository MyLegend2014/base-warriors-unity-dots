using Unity.Burst;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    [UpdateAfter(typeof(TargetPositionSystem))]
    public partial struct TargetDistanceSystem : ISystem
    {
        private float _delayTimer;
        private float _updateDelay;
        private float _defaultDistance;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _updateDelay = 0.5f;
            _defaultDistance = 1f;
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            _delayTimer -= SystemAPI.Time.DeltaTime;
            
            if (_delayTimer > 0)
                return;
            
            foreach (TargetDistanceAspect aspect in SystemAPI.Query<TargetDistanceAspect>())
            {
                if (aspect.IsExistsTarget() == false)
                {
                    aspect.TargetDistance = _defaultDistance;
                    
                    continue;
                }
                
                aspect.TargetDistance = MoveUseCase.CalculateDistance(aspect.TargetPosition, aspect.SelfPosition);
            }
            
            _delayTimer = _updateDelay;
        }
    }
}