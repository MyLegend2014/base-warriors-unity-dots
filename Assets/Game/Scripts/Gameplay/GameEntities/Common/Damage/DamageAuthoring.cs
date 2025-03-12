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
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(new Damage() { Value = authoring.Value});
            }
        }
    }
}