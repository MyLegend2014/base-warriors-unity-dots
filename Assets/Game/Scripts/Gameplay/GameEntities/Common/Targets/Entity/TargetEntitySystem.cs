using Game.Gameplay.GameEntities.Content;
using Unity.Burst;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public partial struct TargetEntitySystem : ISystem
    {
        private float _updateDelay;
        private EntityQuery _unitsQuery;
        private EntityQuery _buildsQuery;
        private float _delayTimer;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _updateDelay = 0.5f;
            
            _unitsQuery = SystemAPI.QueryBuilder()
                .WithAll<UnitTag>()
                .WithAll<Team>()
                .Build();
            
            _buildsQuery = SystemAPI.QueryBuilder()
                .WithAll<BuildTag>()
                .WithAll<Team>()
                .Build();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            _delayTimer -= SystemAPI.Time.DeltaTime;
            
            if (_delayTimer > 0)
                return;
            
            foreach (TargetEntityAspect aspect in SystemAPI.Query<TargetEntityAspect>())
            {
                if (aspect.IsExistsTarget())
                    continue;
                
                if (TargetUseCase.TryFindNearestTarget(in state, aspect.Team, aspect.SelfPosition, 
                        _unitsQuery, out Entity target))
                {
                    aspect.TargetEntity = target;
                }
                else if (TargetUseCase.TryFindNearestTarget(in state, aspect.Team,
                             aspect.SelfPosition, _buildsQuery, out target))
                {
                    aspect.TargetEntity = target;
                }
            }
            
            _delayTimer = _updateDelay;
        }
    }
}