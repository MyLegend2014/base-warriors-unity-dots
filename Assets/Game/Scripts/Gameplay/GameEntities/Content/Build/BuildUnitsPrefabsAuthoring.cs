using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Content
{
    public class BuildUnitsPrefabsAuthoring : MonoBehaviour
    {
        [SerializeField, AssetsOnly] private UnitTagAuthoring[] _unitsPrefabs;
        
        private UnitTagAuthoring[] UnitsPrefabs => _unitsPrefabs;
        
        private class BuildUnitsPrefabsAuthoringBaker : Baker<BuildUnitsPrefabsAuthoring>
        {
            public override void Bake(BuildUnitsPrefabsAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                DynamicBuffer<UnitPrefab> buffer = AddBuffer<UnitPrefab>(entity);

                foreach (UnitTagAuthoring prefab in authoring.UnitsPrefabs)
                    buffer.Add(new UnitPrefab() { Value = GetEntity(prefab, TransformUsageFlags.Dynamic)});
            }
        }
    }
}