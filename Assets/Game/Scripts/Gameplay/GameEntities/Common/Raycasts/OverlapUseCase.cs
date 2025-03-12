using Unity.Collections;
using Unity.Physics;

namespace Game.Gameplay.GameEntities.Common
{
    public struct OverlapUseCase
    {
        public static bool IsExistsOverlapHits(PhysicsWorldSingleton physicsWorld, BoxOverlapInput input, 
            ref NativeList<DistanceHit> hits )
        {
            return physicsWorld.OverlapBox(input.WorldPosition, input.Rotation, input.HalfBoxSize,
                ref hits, CollisionFilter.Default);
        }
    }
}