using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class RotationSpeedAuthoring : MonoBehaviour
    {
        [field: SerializeField, MinValue(0)] public float Value = 3f;
        private class RotationSpeedAuthoringBaker : Baker<RotationSpeedAuthoring>
        {
            public override void Bake(RotationSpeedAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(new RotationSpeed() { Value = authoring.Value});
            }
        }
    }
}