using Game.Gameplay.GameEntites.Common;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class TeamAuthoring : MonoBehaviour
    {
        [field: SerializeField] public TeamColor Value { get; private set; }
        
        private class TeamAuthoringBaker : Baker<TeamAuthoring>
        {
            public override void Bake(TeamAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(new Team() { Value = authoring.Value });
            }
        }
    }
}