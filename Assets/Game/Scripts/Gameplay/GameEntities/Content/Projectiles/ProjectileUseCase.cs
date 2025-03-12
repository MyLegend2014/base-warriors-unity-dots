using Game.Gameplay.GameEntities.Common;
using Unity.Burst;
using Unity.Entities;
using Unity.Physics;

namespace Game.Gameplay.GameEntities.Content
{
    public class ProjectileUseCase
    {
        [BurstCompile]
        public static BoxOverlapInput CalculateBoxOverlapInput(in EntityManager entityManager, 
            in ProjectileAspect projectile)
        {
            Aabb projectileAabb = projectile.Collider.Value.Value.CalculateAabb();

            return new BoxOverlapInput()
            {
                WorldPosition = TransformUseCase.CalculateWorldPosition(entityManager, projectile.Self),
                HalfBoxSize = (projectileAabb.Max - projectileAabb.Min) / 2,
                Rotation = projectile.Rotation,
            };
        }
    }
}