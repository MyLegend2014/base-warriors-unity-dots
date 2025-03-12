using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class StoppingDistanceAuthoring : MonoBehaviour
    {
        [field: SerializeField, MinValue(0)] public float Value = 1f;
        
        private class StoppingDistanceAuthoringBaker : Baker<StoppingDistanceAuthoring>
        {
            public override void Bake(StoppingDistanceAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(new StoppingDistance() { Value = authoring.Value});
            }
        }
    }
}