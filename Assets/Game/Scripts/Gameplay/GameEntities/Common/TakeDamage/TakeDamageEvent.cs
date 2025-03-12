using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Common
{
    public struct TakeDamageEvent : IEvent
    {
        public float3 Position;
    }
}