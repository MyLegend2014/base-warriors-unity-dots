using Unity.Mathematics;

namespace Game.Gameplay.GameEntities.Common
{
    public struct BoxOverlapInput
    {
        public float3 WorldPosition;
        
        public quaternion Rotation;
        
        public float3 HalfBoxSize;
    }
}