using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class SpawnerAuthoring : MonoBehaviour
    {
        private class SpawnerAuthoringBaker : Baker<SpawnerAuthoring>
        {
            public override void Bake(SpawnerAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new SpawnerTag() { Self = entity});
                AddBuffer<SpawnRequest>(entity);
            }
        }
    }
}