using Game.Gameplay.GameEntities.Common;
using Game.Gameplay.GameEntities.Content;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.View
{
    public readonly partial struct MoveAnimationAspect : IAspect
    {
        private readonly RefRO<UnitTag> _unitTag;
        private readonly AnimatorReferenceAspect _animatorReferenceAspect;
        private readonly RefRO<MoveDirection> _moveDirection;
        
        public Entity AnimatorEntity => _animatorReferenceAspect.AnimatorEntity;
        
        public float3 MoveDirection => _moveDirection.ValueRO.Value;
    }
}