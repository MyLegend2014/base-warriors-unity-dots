using Game.Gameplay.Effects;
using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.View
{
    public class ParticlesRegistryPrefabAuthoring : MonoBehaviour
    {
        [Required, AssetsOnly]
        [SerializeField] private ParticlesRegistry _prefab;

        public ParticlesRegistry Prefab => _prefab;
        
        private class ParticlesRegistryPrefabAuthoringBaker : Baker<ParticlesRegistryPrefabAuthoring>
        {
            public override void Bake(ParticlesRegistryPrefabAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponentObject(entity, new ParticlesRegistryPrefab() { Value = authoring.Prefab });
            }
        }
    }
}