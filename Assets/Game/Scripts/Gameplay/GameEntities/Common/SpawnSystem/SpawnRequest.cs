using Unity.Entities;
using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Common
{
    public struct SpawnRequest : IBufferedRequest
    {
        public Entity Prefab;

        public float3 Position;
        
        public quaternion Rotation;
    }
}