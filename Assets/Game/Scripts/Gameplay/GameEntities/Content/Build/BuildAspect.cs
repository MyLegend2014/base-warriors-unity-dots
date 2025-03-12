using Game.Gameplay.GameEntites.Common;
using Game.Gameplay.GameEntities.Common;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Gameplay.GameEntities.Content
{
    public readonly partial struct BuildAspect : IAspect
    {
        private readonly RefRO<BuildTag> _build;
        private readonly RefRO<LocalTransform> _localTransform;
        private readonly RefRO<Team> _team;

        public readonly Entity Self;
        
        public float3 Position => _localTransform.ValueRO.Position;
        
        public TeamColor TeamColor => _team.ValueRO.Value;
    }
}