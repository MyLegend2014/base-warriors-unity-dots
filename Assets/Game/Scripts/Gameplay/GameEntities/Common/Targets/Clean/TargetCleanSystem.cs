using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Common
{
    [UpdateAfter(typeof(DestroySystem))]
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
    public partial struct TargetCleanSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (TargetCleanAspect attackerAspect in SystemAPI.Query<TargetCleanAspect>())
            {
                if (SystemAPI.HasComponent<LocalTransform>(attackerAspect.TargetEntity) == false)
                    attackerAspect.TargetEntity = Entity.Null;
            }
        }
    }
}