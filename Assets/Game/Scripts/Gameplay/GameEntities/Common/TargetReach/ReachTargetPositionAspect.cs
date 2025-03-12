using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct ReachTargetPositionAspect : IAspect
    {
        private readonly RefRO<TargetDistance> _targetDistance;
        private readonly RefRO<StoppingDistance> _stoppingDistance;
        
        public bool IsReachedTarget => _targetDistance.ValueRO.Value <= _stoppingDistance.ValueRO.Value;
    }
}