using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class SpawnPointsAuthoring : MonoBehaviour
    {
        [field: SerializeField] public Transform[] SpawnPoints { get; private set; }
        
        private class SpawnPointsAuthoringBaker : Baker<SpawnPointsAuthoring>
        {
            public override void Bake(SpawnPointsAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                DynamicBuffer<SpawnPointBuffer> buffer = AddBuffer<SpawnPointBuffer>(entity);

                foreach (Transform point in authoring.SpawnPoints)
                    buffer.Add(new SpawnPointBuffer() { Value = GetEntity(point, TransformUsageFlags.Dynamic)});
            }
        }
    }
}