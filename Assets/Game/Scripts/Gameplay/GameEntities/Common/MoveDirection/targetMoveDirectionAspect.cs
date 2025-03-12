using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    public readonly partial struct targetMoveDirectionAspect : IAspect
    {
        private readonly RefRW<MoveDirection> _direction;
        private readonly RefRO<LocalTransform> _localTransform;
        private readonly RefRO<TargetPosition> _targetPosition;
        [Optional] private readonly RefRO<StoppingDistance> _stoppingDistance;
        [Optional] private readonly RefRO<TargetDistance> _targetDistance;

        public float3 TargetPosition => _targetPosition.ValueRO.Value;
        
        public float StoppingDistance
        {
            get
            {
                if (IsExistsStoppingDistance() == false)
                    throw new System.Exception("Stopping distance is not exists");
                
                return _stoppingDistance.ValueRO.Value;
            }
        }
        
        public float TargetDistance
        {
            get
            {
                if (IsExistTargetDistance() == false)
                    throw new System.Exception("Target distance is not exists");
                
                return _targetDistance.ValueRO.Value;
            }
        }

        public float3 MoveDirection
        {
            get => _direction.ValueRO.Value;
            set => _direction.ValueRW.Value = value;
        }
        
        public float3 SelfPosition => _localTransform.ValueRO.Position;
        
        public bool IsExistsStoppingDistance() => _stoppingDistance.IsValid;
        
        public bool IsExistTargetDistance() => _targetDistance.IsValid;
    }
}