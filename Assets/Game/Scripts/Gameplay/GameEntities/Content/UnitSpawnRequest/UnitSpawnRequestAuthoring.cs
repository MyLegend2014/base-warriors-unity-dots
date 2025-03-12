using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Content
{
    public class UnitSpawnRequestAuthoring : MonoBehaviour
    {
        private class UnitSpawnRequestAuthoringBaker : Baker<UnitSpawnRequestAuthoring>
        {
            public override void Bake(UnitSpawnRequestAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<UnitSpawnRequest>();
                SetComponentEnabled<UnitSpawnRequest>(false);
            }
        }
    }
}