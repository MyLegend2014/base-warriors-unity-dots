using Unity.Burst;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Content
{
    public partial struct ProjectileMoveDirectionSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (ProjectileMoveDirectionAspect aspect in SystemAPI.Query<ProjectileMoveDirectionAspect>())
            {
                if (aspect.IsAlive == false)
                    continue;

                if (aspect.IsExistsMoveDirection())
                    continue;

                aspect.InitializeMoveDirection();
            }
        }
    }
}