using Unity.Entities;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Common
{
    public struct MoveDirection : IComponentData
    {
        public float3 Value;
    }
}