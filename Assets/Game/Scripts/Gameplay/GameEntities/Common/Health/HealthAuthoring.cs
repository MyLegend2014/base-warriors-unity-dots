using Game.Gameplay.GameEntities.Common;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.Core
{
    public class HealthAuthoring : MonoBehaviour
    {
        [field: SerializeField] public int MaxValue { get; private set; } = 100;
        
        private class HealthAuthoringBaker : Baker<HealthAuthoring>
        {
            public override void Bake(HealthAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(new Health { MaxValue = authoring.MaxValue, Value = authoring.MaxValue});
                
                AddComponent<TakeDamageEvent>();
                SetComponentEnabled<TakeDamageEvent>(entity, false);
                
                AddComponent<DieEvent>();
                SetComponentEnabled<DieEvent>(entity, false);
                
                AddBuffer<TakeDamageRequest>();
            }
        }
    }
}