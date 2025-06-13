using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class DamageAuthoring : MonoBehaviour
    {
        [field: SerializeField, MinValue(0)] public int Value = 5;
        
        private class DamageAuthoringBaker : Baker<DamageAuthoring>
        {
            public override void Bake(DamageAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new Damage() { Value = authoring.Value});
            }
        }
    }
}