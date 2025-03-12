using Unity.Burst;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public partial struct AttackCooldownSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (AttackCooldownAspect aspect in SystemAPI.Query<AttackCooldownAspect>())
            {
                aspect.CurrentValue -= SystemAPI.Time.DeltaTime;
            }
        }
    }
}