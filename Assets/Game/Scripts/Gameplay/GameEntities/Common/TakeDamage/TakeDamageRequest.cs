using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Common
{
    public struct TakeDamageRequest : IBufferedRequest
    {
        public int Damage;
        
        public float3 Position;
    }
}