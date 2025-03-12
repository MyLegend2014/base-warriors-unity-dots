using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class LifetimeAuthoring : MonoBehaviour
    {
        [field: SerializeField, MinValue(0)] public float MaxValue = 7;
        private class LifetimeAuthoringBaker : Baker<LifetimeAuthoring>
        {
            public override void Bake(LifetimeAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(new Lifetime()
                {
                    CurrentValue = authoring.MaxValue,
                    MaxValue = authoring.MaxValue
                });
            }
        }
    }
}